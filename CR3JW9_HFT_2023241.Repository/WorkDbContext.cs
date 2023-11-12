using CR3JW9_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                builder.UseInMemoryDatabase("workdb").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Person>(
                person => person.HasOne<Job>().WithMany().HasForeignKey(person => person.JobID)
                .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Models.Job>(
                job => job.HasOne<Job>().WithMany().HasForeignKey(job => job.JobID)
                .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Models.Computer>(
                computer => computer.HasOne<Computer>().WithMany().HasForeignKey(computer => computer.ComputerID)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new Person(001, 100, "John", 40, DateTime.Parse("1983.10.10"), DateTime.Parse("2010.05.05")),
                new Person(002, 80, "Claire", 40, DateTime.Parse("1990.08.20"), DateTime.Parse("2018.12.01")),
                new Person(003, 130, "Tom", 40, DateTime.Parse("1960.02.25"), DateTime.Parse("1997.08.13"))
            });
            modelBuilder.Entity<Job>().HasData(new Job[]
            {
                new Job(100, "Programmer", "Seattle", 10000),
                new Job(80, "HR", "New York", 7000),
                new Job(130, "Manager", "Washington", 13000)
            });
            modelBuilder.Entity<Computer>().HasData(new Computer[]
            {
                new Computer(1, 16, DateTime.Parse("2022.10.25"), "AMD", "Nvidia", "Ryzen 5", "RTX 2060"),
                new Computer(2, 32, DateTime.Parse("2023.08.10"), "Intel", "Nvidia", "i9", "RTX 4080"),
                new Computer(3, 8, DateTime.Parse("2021.12.14"), "Intel", "none", "i3", "none"),
            });
        }
    }
}
