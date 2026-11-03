using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Models;

public class WebSalesMVCContext(DbContextOptions<WebSalesMVCContext> options) : DbContext(options)
{
    public DbSet<Department> Department { get; set; }
    public DbSet<Seller> Seller { get; set; }
    public DbSet<SalesRecord> SalesRecord { get; set; }
}
