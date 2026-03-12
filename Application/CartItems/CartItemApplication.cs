using Application.CartItems.Dto;
using Data.CartItems;
using Domain;

namespace Application.CartItems;

public class CartItemApplication : ICartItemApplication
{
    private readonly ICartItemRepository _cartItemRepository;

    public CartItemApplication(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task<string> Create(CreateCartItemDto dto)
    {
        var cartItem = new CartItem
        {
            Quantity = dto.Quantity,
            GymProductId = dto.GymProductId
        };

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

        return cartItems.Select(c => new CartItemDto
        {
            Id = c.Id,
            Quantity = c.Quantity,
            GymProductId = c.GymProductId
        }).ToList();
    }

    public async Task<CartItemDto> GetById(int id)
    {
        var cartItem = await _cartItemRepository.GetById(id);

        if (cartItem == null)
            return null;

        return new CartItemDto
        {
            Id = cartItem.Id,
            Quantity = cartItem.Quantity,
            GymProductId = cartItem.GymProductId
        };
    }
}