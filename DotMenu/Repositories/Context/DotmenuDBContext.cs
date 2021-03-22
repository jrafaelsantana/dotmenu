using DotMenu.Models;
using DotMenu.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DotMenu.Repositories.Context
{
    public class DotmenuDBContext : DbContext
    {
        public DotmenuDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}