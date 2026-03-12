using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.CartItems;

public class CartItemRepository:ICartItemRepository
{
    private readonly DataContext _context;

    public CartItemRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var cartItems = await _context.CartItems.FindAsync(id);
        _context.CartItems.Remove(cartItems);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<CartItem>> GetAll()
    {
        var cartItems = await _context.CartItems.ToListAsync();
        return cartItems;
    }

    public async Task<CartItem> GetById(int id)
    {
        return await _context.CartItems.FindAsync(id);
    }
    public async Task<CartItem> Create(CartItem cartItems)
    {
        await _context.CartItems.AddAsync(cartItems);
        await _context.SaveChangesAsync();

        return cartItems;
    }

    public async Task Update(CartItem cartItems)
    {
        _context.CartItems.Update(cartItems);
        await _context.SaveChangesAsync();
    }
}