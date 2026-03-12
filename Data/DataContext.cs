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
    public DbSet<DietType> DiteTypes { get; set; }
    public DbSet<Diet> Dites { get; set; }
    public DbSet<DietDocument> DietDocuments { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseDocument> ExerciseDocuments { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<GymDocument> GymDocuments { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<GymProduct> GymProducts { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<ProductDocument> ProductDocuments { get; set; }
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }
    public DbSet<SalePayment> SalePayments { get; set; }



}