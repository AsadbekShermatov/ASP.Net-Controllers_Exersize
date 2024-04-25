using Microsoft.EntityFrameworkCore;

namespace FrameWork
{
    internal class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-G3SP2SRJPL7; Database=ProductvsCategory; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
