using Microsoft.EntityFrameworkCore;
using Restorani.ba.Models;

namespace Restorani.ba.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Restoran> Restorani { get; set; } 
        public DbSet<Jelo> Jela { get; set; }
    }
}
