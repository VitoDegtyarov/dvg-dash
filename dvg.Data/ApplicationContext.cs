using dvg.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace dvg.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
