using CR3JW9_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Repository
{
    public class WorkDbContext : DbContext
    {
        public DbSet<Models.Computer> Computers { get; set; }
        public DbSet<Models.Job> Jobs { get; set; }
        public DbSet<Models.Person> Persons { get; set; }

        public WorkDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = "";
                builder.UseInMemoryDatabase("work.mdf").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Person>(
                person => person.HasOne<Job>().WithMany().HasForeignKey(person => person.JobID)
                .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
