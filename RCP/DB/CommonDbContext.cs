using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.DB
{
    public class CommonDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Report> Reports { get; set; }

        private readonly DbContextOptions _options;

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
            _options = options;
        }
    }
}