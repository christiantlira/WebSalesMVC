using Microsoft.EntityFrameworkCore;

public class WebSalesMVCContext(DbContextOptions<WebSalesMVCContext> options) : DbContext(options)
{
    public DbSet<WebSalesMVC.Models.Department> Department { get; set; } = default!;
}
