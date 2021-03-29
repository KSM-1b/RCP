using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.DB
{
    public class CommonDbContext : DbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<Report> Reports { get; set; }

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Worker);
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Client);
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Job);
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.User);
        }
    }
}