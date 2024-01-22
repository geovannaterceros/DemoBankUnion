using DemoBank.DAL.Database.DBModels;
using Microsoft.EntityFrameworkCore;

namespace DemoBank.DAL.Database;

    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
      : base(options)
        {

        }

        public virtual DbSet<AccountOpening> AccountOpening { get; set; }

        public virtual DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountOpening>().ToTable("AccountOpening");
            modelBuilder.Entity<Client>().ToTable("Clients");
        }
    }

