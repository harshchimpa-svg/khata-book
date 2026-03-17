using System.Security.Claims;
using Application.Customers.Dto;
using AutoMapper;
using Data.Customers;
using Data.Services;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Customers;

public class CustomerApplication : ICustomerApplication
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IFileService _fileService;
    private readonly IEmailService _emailService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public CustomerApplication(
        ICustomerRepository customerRepository,
        IFileService fileService,
        IEmailService emailService,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _fileService = fileService;
        _emailService = emailService;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    private string GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            throw new Exception("User not authenticated");

        return userId;
    }

    public async Task<string> Create(CreateCustomerDto dto)
    {
        string userId = GetUserId();

        var imagePath = await _fileService.UploadImage(dto.Profile, "customer");

        var customer = _mapper.Map<Customer>(dto);
        customer.UserId = userId;
        customer.Profile = imagePath;

        await _customerRepository.Create(customer);

        return "Customer Created";
    }

    public async Task Delete(int id)
    {
        var userId = GetUserId();

        var customer = await _customerRepository.GetById(id);

        if (customer == null || customer.UserId != userId)
            throw new Exception("Unauthorized access");

        await _customerRepository.Delete(id);
    }

    public async Task<List<CustomerDto>> GetAll()
    {
        var userId = GetUserId();

        var customers = await _customerRepository.GetAll();

        var userCustomers = customers
            .Where(x => x.UserId == userId)
            .ToList();

        return _mapper.Map<List<CustomerDto>>(userCustomers);
    }

    public async Task<CustomerDto> GetById(int id)
    {
        var userId = GetUserId();

        var customer = await _customerRepository.GetById(id);

        if (customer == null || customer.UserId != userId)
            throw new Exception("Unauthorized access");

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task Update(int id, CreateCustomerDto input)
    {
        var userId = GetUserId();

        var customer = await _customerRepository.GetById(id);

        if (customer == null || customer.UserId != userId)
            throw new Exception("Unauthorized access");

        if (input.Profile != null)
        {
            _fileService.DeleteImage(customer.Profile);

            var imagePath = await _fileService.UploadImage(input.Profile, "customer");
            customer.Profile = imagePath;
        }

        customer.Name = input.Name;
        customer.Email = input.Email;
        customer.PhoneNumber = input.PhoneNumber;
        customer.Notes = input.Notes;
        customer.Balance = input.Balance;

        await _customerRepository.Update(customer);
    }

    public async Task<string> BlockCustomer(int id)
    {
        var userId = GetUserId();

        var customer = await _customerRepository.GetById(id);

        if (customer == null || customer.UserId != userId)
            throw new Exception("Unauthorized access");

        customer.IsActive = !customer.IsActive;

        await _customerRepository.Update(customer);

        return "Customer status updated";
    }

    public async Task<string> SendReminder()
    {
        var userId = GetUserId();

        var customers = await _customerRepository.GetAll();

        var pendingCustomers = customers
            .Where(x => x.UserId == userId && x.Balance > 0 && x.IsActive && !string.IsNullOrEmpty(x.Email))
            .ToList();

        if (!pendingCustomers.Any())
            return "No pending customers found";

        foreach (var customer in pendingCustomers)
        {
            var subject = "Payment Reminder - Pending Amount";

            var body = $@"
Hello {customer.Name}

This is a friendly reminder.

Your Pending Amount is:

₹{customer.Balance}

Please clear your dues as soon as possible.

Thank you.";

            await _emailService.SendEmail(customer.Email, subject, body);
        }

        return "Reminder emails sent successfully";
    }
}