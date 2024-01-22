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

        //public virtual DbSet<Account> Account { get; set; }

        //public virtual DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().ToTable("Accounts");
            //modelBuilder.Entity<Client>().ToTable("Clients");
        }
    }

