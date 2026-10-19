using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Models
{
    public class ComputerShopDbContext : DbContext
    {
        public ComputerShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public ComputerShopDbContext()
        {

        }

        public DbSet<Osystem> Osystems { get; set; }
        public DbSet<Computer> Computers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "server=localhost;database=computershop;uid=root;password=password";

            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }
}
