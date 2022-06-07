using Employee.Temperature.Record.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Temperature.Record.Api.Entity {
    public partial class AppDbContext : DbContext {
        public DbSet<Laborer> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Inversion> Temperature { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder
                    .UseSqlServer("Server=.\\SQLExpress;Database=Employee.Temperature.Record.Data.DbContext;Trusted_Connection=True;");
            }
        }
    }
}
