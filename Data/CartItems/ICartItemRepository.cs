using Domain;

namespace Data.CartItems;

public interface ICartItemRepository
{
    Task Delete(int id);
    Task<CartItem> GetById(int id);
    Task Update(CartItem cartItem);
    Task<List<CartItem>> GetAll();
    Task<CartItem> Create(CartItem cartItem);
}