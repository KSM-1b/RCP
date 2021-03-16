using Microsoft.EntityFrameworkCore;
using RCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.DB
{
    public class CommonDbContext : DbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<Worker> Workers { get; set; }

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {

        }
    }
}