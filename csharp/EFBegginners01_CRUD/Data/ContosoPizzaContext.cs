using Microsoft.EntityFrameworkCore;


public class ContosoPizzaContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;           

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(@"Server=localhost;Port=44557;Database=account;User Id=admin;Password=leapeHxTWGsesRC00lJn;");
    }

}
