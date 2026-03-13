using Application.CartItems.Dto;

namespace Application.CartItems;

public interface ICartItemApplication
{
    Task<string> Create(CreateCartItemDto dto);
    Task Delete(int id);
    Task<List<CartItemDto>> GetAll();
    Task<CartItemDto> GetById(int id);
    Task Update(int id, CreateCartItemDto update);
}