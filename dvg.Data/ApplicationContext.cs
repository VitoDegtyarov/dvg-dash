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
            SetTestData(modelBuilder);
        }

        private void SetTestData(ModelBuilder modelBuilder)
        {
            var designers = new List<Designer>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    FirstName = "Kate",
                    LastName = "Ivanka",
                    PhoneNumber = "+380991002030",
                    Position = Core.Enums.DesignerPosition.Senior

                },

                new()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    FirstName = "Valeria",
                    LastName = "Wayne",
                    PhoneNumber = "+380661003040",
                    Position = Core.Enums.DesignerPosition.Middle
                }
            };

            var clients = new List<Client>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    FirstName = "Alex",
                    LastName = "Freeman",
                    PhoneNumber = "+380939876532"
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    FirstName = "Igor",
                    LastName = "Kowalski",
                    PhoneNumber = "+380631234567"
                }
            };

            modelBuilder.Entity<Designer>().HasData(designers);
            modelBuilder.Entity<Client>().HasData(clients);
        }
    }
}
