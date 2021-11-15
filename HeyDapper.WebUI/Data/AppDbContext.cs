using HeyDapper.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyDapper.WebUI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
    }
}
