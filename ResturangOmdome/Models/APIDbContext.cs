using Microsoft.EntityFrameworkCore;
using ResturangOmdome.Models;

public class APIDbContext : DbContext
{
    public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }

    public DbSet<Omdome> Omdomen { get; set; }

    

}
