using ASP.Net_Controllers_Exersize.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Controllers_Exersize.Context
{
    public class AppDBContext :DbContext
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }

    }
}
