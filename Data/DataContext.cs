using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ShopSetting> ShopSettings { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Otp> Otps { get; set; }
    public DbSet<PaymentLog> PaymentLogs { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<DiteType> DiteTypes { get; set; }
    public DbSet<Diet> Dites { get; set; }
    // public DbSet<Category> Categorys { get; set; }
    // public DbSet<Category> Categorys { get; set; }


}