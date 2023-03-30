using Microsoft.EntityFrameworkCore;
using PetStore.Entities;

namespace PetStore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
