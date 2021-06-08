﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.DB
{
    public class CommonDbContext : IdentityDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<Report> Reports { get; set; }

        private readonly DbContextOptions _options;

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
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