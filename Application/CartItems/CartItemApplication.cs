using Application.CartItems.Dto;
using AutoMapper;
using Data.CartItems;
using Domain;

namespace Application.CartItems;

public class CartItemApplication : ICartItemApplication
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public CartItemApplication(ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }


    public CartItemApplication(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task<string> Create(CreateCartItemDto dto)
    {
        CartItem cartItem = _mapper.Map<CartItem>(dto);

        await _cartItemRepository.Create(cartItem);

        return "Cart Item Created";
    }

    public async Task Update(int id, CreateCartItemDto dto)
    {
        var cartItem = await _cartItemRepository.GetById(id);

        if (cartItem == null)
            throw new Exception("Cart Item not found");

        cartItem.Quantity = dto.Quantity;
        cartItem.GymProductId = dto.GymProductId;

        await _cartItemRepository.Update(cartItem);
    }

    public async Task Delete(int id)
    {
        await _cartItemRepository.Delete(id);
    }

    public async Task<List<CartItemDto>> GetAll()
    {
        var cartItems = await _cartItemRepository.GetAll();

        return _mapper.Map<List<CartItemDto>>(cartItems);
    }

    public async Task<CartItemDto> GetById(int id)
    {
        var cartItem = await _cartItemRepository.GetById(id);

        if (cartItem == null)
            return null;
        
        return _mapper.Map<CartItemDto>(cartItem);
    }
}