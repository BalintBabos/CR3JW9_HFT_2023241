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
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Person> Persons { get; set; }

        public WorkDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //           string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                //AttachDbFilename=|DataDirectory|\work.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                //           builder.UseLazyLoadingProxies().UseSqlServer(conn);
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("workdb");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(
                person => person.HasOne<Job>().WithMany(job => job.Persons).HasForeignKey(person => person.JobID)
                .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Models.Job>(
                job => job.HasMany(job => job.Persons).WithOne(job => job.Job)
                .HasForeignKey(job => job.JobID).OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Computer>(
                computer => computer.HasOne(computer => computer.Person).WithMany(person => person.Computers).HasForeignKey(computer => computer.PersonID)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new Person(101, 100, "John Smith", 40, DateTime.Parse("1983.10.10"), DateTime.Parse("2010.05.05")),
                new Person(102, 80, "Claire White", 40, DateTime.Parse("1990.08.20"), DateTime.Parse("2018.12.01")),
                new Person(103, 130, "Tom Branford", 40, DateTime.Parse("1960.02.25"), DateTime.Parse("1997.08.13")),
                new Person(104, 105, "Emily Johnson", 35, DateTime.Parse("1987.06.15"), DateTime.Parse("2015.09.20")),
                new Person(105, 120, "Michael Smith", 45, DateTime.Parse("1978.03.28"), DateTime.Parse("2005.11.12")),
                new Person(106, 110, "Sophia Williams", 28, DateTime.Parse("1995.11.05"), DateTime.Parse("2020.04.03")),
                new Person(107, 115, "Daniel Brown", 50, DateTime.Parse("1972.09.10"), DateTime.Parse("2000.12.30")),
                new Person(108, 125, "Olivia Jones", 33, DateTime.Parse("1989.12.22"), DateTime.Parse("2016.07.18")),
                new Person(109, 100, "William Davis", 38, DateTime.Parse("1984.08.08"), DateTime.Parse("2011.12.05")),
                new Person(110, 105, "Ava Miller", 29, DateTime.Parse("1994.04.30"), DateTime.Parse("2019.10.22")),
                new Person(111, 120, "Aria Kelly", 31, DateTime.Parse("1992.11.15"), DateTime.Parse("2019.03.18")),
                new Person(112, 115, "Eli Turner", 39, DateTime.Parse("1983.12.08"), DateTime.Parse("2011.04.25")),
                new Person(113, 100, "Grace Cooper", 26, DateTime.Parse("1997.09.21"), DateTime.Parse("2024.01.14")),
                new Person(114, 105, "Mila Richardson", 42, DateTime.Parse("1981.05.24"), DateTime.Parse("2008.08.07")),
                new Person(115, 125, "Carter Wood", 37, DateTime.Parse("1985.02.17"), DateTime.Parse("2012.06.30")),
                new Person(116, 110, "Nova Brooks", 29, DateTime.Parse("1994.07.10"), DateTime.Parse("2021.10.23")),
                new Person(117, 120, "Grayson Watson", 45, DateTime.Parse("1978.03.03"), DateTime.Parse("2005.06.15")),
                new Person(118, 115, "Layla Morgan", 33, DateTime.Parse("1989.01.26"), DateTime.Parse("2016.04.09")),
                new Person(119, 100, "Zachary Price", 28, DateTime.Parse("1995.04.30"), DateTime.Parse("2022.08.02")),
                new Person(120, 105, "Riley Hughes", 36, DateTime.Parse("1987.08.12"), DateTime.Parse("2014.11.27")),
                new Person(121, 110, "Hannah Sanders", 30, DateTime.Parse("1992.06.25"), DateTime.Parse("2019.09.08")),
                new Person(122, 120, "Isaac Simmons", 43, DateTime.Parse("1980.10.18"), DateTime.Parse("2007.12.21")),
                new Person(123, 125, "Eleanor Patterson", 34, DateTime.Parse("1988.07.09"), DateTime.Parse("2015.10.04")),
                new Person(124, 100, "Nathan Perry", 27, DateTime.Parse("1996.12.12"), DateTime.Parse("2023.03.18")),
                new Person(125, 105, "Violet Foster", 44, DateTime.Parse("1979.11.05"), DateTime.Parse("2006.02.08")),
                new Person(126, 110, "Bentley Long", 32, DateTime.Parse("1991.04.28"), DateTime.Parse("2018.07.01")),
                new Person(127, 115, "Stella Reed", 38, DateTime.Parse("1984.02.19"), DateTime.Parse("2011.05.24")),
                new Person(128, 120, "Gabriel Ward", 41, DateTime.Parse("1981.09.22"), DateTime.Parse("2008.12.05")),
                new Person(129, 125, "Aurora Barnes", 35, DateTime.Parse("1987.06.07"), DateTime.Parse("2014.09.18")),
                new Person(130, 100, "Owen Fisher", 46, DateTime.Parse("1977.03.30"), DateTime.Parse("2004.06.13")),
                new Person(131, 105, "Avery Marshall", 29, DateTime.Parse("1994.08.24"), DateTime.Parse("2021.12.07")),
                new Person(132, 110, "Zoey Cooper", 47, DateTime.Parse("1976.06.17"), DateTime.Parse("2003.09.20")),
                new Person(133, 115, "Eliana Ross", 36, DateTime.Parse("1987.11.30"), DateTime.Parse("2015.03.14")),
                new Person(134, 120, "Christian Morris", 31, DateTime.Parse("1992.09.13"), DateTime.Parse("2019.01.26")),
                new Person(135, 125, "Piper Bell", 42, DateTime.Parse("1981.12.26"), DateTime.Parse("2009.04.10")),
                new Person(136, 100, "Levi Henderson", 30, DateTime.Parse("1992.05.19"), DateTime.Parse("2019.08.22")),
                new Person(137, 105, "Addison Perry", 33, DateTime.Parse("1989.02.22"), DateTime.Parse("2016.05.05")),
                new Person(138, 110, "Elena Richardson", 28, DateTime.Parse("1995.07.05"), DateTime.Parse("2022.10.18")),
                new Person(139, 115, "Nicholas Hughes", 45, DateTime.Parse("1978.04.08"), DateTime.Parse("2005.07.31")),
                new Person(140, 120, "Skylar Carter", 38, DateTime.Parse("1984.03.21"), DateTime.Parse("2011.06.13")),
                new Person(141, 125, "Claire Gray", 34, DateTime.Parse("1988.01.14"), DateTime.Parse("2015.04.27")),
                new Person(142, 100, "Zander Watson", 26, DateTime.Parse("1997.12.27"), DateTime.Parse("2025.03.02")),
                new Person(143, 105, "Mackenzie Parker", 43, DateTime.Parse("1980.09.10"), DateTime.Parse("2008.12.23")),
                new Person(144, 110, "Isabelle Flores", 32, DateTime.Parse("1991.06.03"), DateTime.Parse("2018.09.06")),
                new Person(145, 115, "Eliana Morgan", 39, DateTime.Parse("1983.08.16"), DateTime.Parse("2010.11.29")),
                new Person(146, 120, "Gavin Adams", 27, DateTime.Parse("1996.02.09"), DateTime.Parse("2023.05.14")),
                new Person(147, 125, "Lily Wood", 44, DateTime.Parse("1979.05.22"), DateTime.Parse("2006.08.05")),
                new Person(148, 100, "Oscar Ramirez", 35, DateTime.Parse("1987.10.25"), DateTime.Parse("2014.01.17")),
                new Person(149, 105, "Hazel Martin", 46, DateTime.Parse("1977.07.28"), DateTime.Parse("2004.10.01")),
                new Person(150, 110, "Ivy Campbell", 37, DateTime.Parse("1985.04.01"), DateTime.Parse("2012.07.14"))
            });
            modelBuilder.Entity<Job>().HasData(new Job[]
            {
                new Job(10, "Software Engineer", "San Francisco", 10000),
                new Job(20, "Data Scientist", "New York", 11000),
                new Job(30, "Cybersecurity Analyst", "Seattle", 10000),
                new Job(40, "Product Manager", "Austin", 11500),
                new Job(50, "UX/UI Designer", "Los Angeles", 9500),
                new Job(60, "Cloud Solutions Architect", "Chicago", 12000),
                new Job(70, "Business Analyst", "Denver", 9700),
                new Job(80, "Network Engineer", "Boston", 10200),
                new Job(90, "AI/Machine Learning Engineer", "Atlanta", 11200),
                new Job(100, "DevOps Engineer", "Houston", 9800),
                new Job(10, "Software Engineer", "San Jose", 10500),
                new Job(20, "Data Scientist", "Washington, D.C.", 11000),
                new Job(30, "Cybersecurity Analyst", "Dallas", 10000),
                new Job(40, "Product Manager", "Miami", 11500),
                new Job(50, "UX/UI Designer", "Philadelphia", 9500),
                new Job(60, "Cloud Solutions Architect", "Phoenix", 12000),
                new Job(70, "Business Analyst", "Las Vegas", 9700),
                new Job(80, "Network Engineer", "San Diego", 10200),
                new Job(90, "AI/Machine Learning Engineer", "Portland", 11200),
                new Job(100, "DevOps Engineer", "New Orleans", 9800),
                new Job(10, "Software Engineer", "Austin", 10500),
                new Job(20, "Data Scientist", "Seattle", 11000),
                new Job(30, "Cybersecurity Analyst", "New York", 10000),
                new Job(40, "Product Manager", "San Francisco", 11500),
                new Job(50, "UX/UI Designer", "Boston", 9500),
                new Job(60, "Cloud Solutions Architect", "Los Angeles", 12000),
                new Job(70, "Business Analyst", "Chicago", 9700),
                new Job(80, "Network Engineer", "Denver", 10200),
                new Job(90, "AI/Machine Learning Engineer", "Houston", 11200),
                new Job(100, "DevOps Engineer", "Atlanta", 9800),
                new Job(10, "Software Engineer", "San Francisco", 10500),
                new Job(20, "Data Scientist", "Seattle", 11000),
                new Job(30, "Cybersecurity Analyst", "New York", 10000),
                new Job(40, "Product Manager", "Austin", 11500),
                new Job(50, "UX/UI Designer", "Los Angeles", 9500),
                new Job(60, "Cloud Solutions Architect", "Chicago", 12000),
                new Job(70, "Business Analyst", "Denver", 9700),
                new Job(80, "Network Engineer", "Boston", 10200),
                new Job(90, "AI/Machine Learning Engineer", "Atlanta", 11200),
                new Job(100, "DevOps Engineer", "Houston", 9800),
                new Job(10, "Software Engineer", "San Jose", 10500),
                new Job(20, "Data Scientist", "Washington, D.C.", 11000),
                new Job(30, "Cybersecurity Analyst", "Dallas", 10000),
                new Job(40, "Product Manager", "Miami", 11500),
                new Job(50, "UX/UI Designer", "Philadelphia", 9500),

            });
            modelBuilder.Entity<Computer>().HasData(new Computer[]
            {
                new Computer(1, 102, 16, DateTime.Parse("2022.10.25"), "AMD", "Nvidia", "Ryzen 5", "RTX 2060"),
                new Computer(2, 101, 32, DateTime.Parse("2023.08.10"), "Intel", "Nvidia", "i9", "RTX 4080"),
                new Computer(3, 103, 8, DateTime.Parse("2021.12.14"), "Intel", "none", "i3", "none"),
                new Computer(4, 104, 16, DateTime.Parse("2022.05.18"), "AMD", "AMD", "Ryzen 7", "RX 6700 XT"),
                new Computer(5, 105, 32, DateTime.Parse("2023.06.30"), "Intel", "Nvidia", "i7", "RTX 3070"),
                new Computer(6, 106, 8, DateTime.Parse("2021.11.22"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(7, 107, 16, DateTime.Parse("2022.09.05"), "Intel", "AMD", "i5", "RX 6600"),
                new Computer(8, 108, 32, DateTime.Parse("2023.07.12"), "AMD", "Nvidia", "Ryzen 9", "RTX 3080"),
                new Computer(9, 109, 8, DateTime.Parse("2021.10.28"), "Intel", "none", "Celeron", "none"),
                new Computer(10, 110, 16, DateTime.Parse("2022.08.15"), "AMD", "AMD", "Ryzen 7", "RX 6800"),
                new Computer(11, 111, 32, DateTime.Parse("2023.04.20"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(12, 112, 8, DateTime.Parse("2021.09.10"), "AMD", "none", "Athlon", "none"),
                new Computer(13, 113, 16, DateTime.Parse("2022.07.05"), "Intel", "AMD", "i5", "RX 6700"),
                new Computer(14, 114, 32, DateTime.Parse("2023.03.01"), "AMD", "Nvidia", "Ryzen 9", "RTX 3060"),
                new Computer(15, 115, 8, DateTime.Parse("2021.08.24"), "Intel", "none", "Pentium", "none"),
                new Computer(16, 116, 16, DateTime.Parse("2022.06.10"), "AMD", "AMD", "Ryzen 5", "RX 6600 XT"),
                new Computer(17, 117, 32, DateTime.Parse("2023.02.15"), "Intel", "Nvidia", "i7", "RTX 2080"),
                new Computer(18, 118, 8, DateTime.Parse("2021.07.18"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(19, 119, 16, DateTime.Parse("2022.04.12"), "Intel", "AMD", "i3", "RX 6500 XT"),
                new Computer(20, 120, 32, DateTime.Parse("2023.01.05"), "AMD", "Nvidia", "Ryzen 7", "RTX 3050"),
                new Computer(21, 121, 8, DateTime.Parse("2021.06.30"), "Intel", "none", "Celeron", "none"),
                new Computer(22, 122, 16, DateTime.Parse("2022.03.25"), "AMD", "AMD", "Ryzen 9", "RX 6900 XT"),
                new Computer(23, 123, 32, DateTime.Parse("2022.12.20"), "Intel", "Nvidia", "i9", "RTX 3060 Ti"),
                new Computer(24, 124, 8, DateTime.Parse("2021.05.15"), "AMD", "none", "Athlon", "none"),
                new Computer(25, 125, 16, DateTime.Parse("2022.02.08"), "Intel", "AMD", "i5", "RX 6700 XT"),
                new Computer(26, 126, 32, DateTime.Parse("2022.11.02"), "AMD", "Nvidia", "Ryzen 5", "RTX 2070"),
                new Computer(27, 127, 8, DateTime.Parse("2021.04.25"), "Intel", "none", "Pentium", "none"),
                new Computer(28, 128, 16, DateTime.Parse("2022.01.20"), "AMD", "AMD", "Ryzen 7", "RX 6800 XT"),
                new Computer(29, 129, 32, DateTime.Parse("2022.10.15"), "Intel", "Nvidia", "i7", "RTX 3080 Ti"),
                new Computer(30, 130, 8, DateTime.Parse("2021.03.10"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(31, 131, 16, DateTime.Parse("2021.12.05"), "Intel", "AMD", "i3", "RX 6600"),
                new Computer(32, 132, 32, DateTime.Parse("2022.09.30"), "AMD", "Nvidia", "Ryzen 9", "RTX 3050 Ti"),
                new Computer(33, 133, 8, DateTime.Parse("2021.02.23"), "Intel", "none", "Celeron", "none"),
                new Computer(34, 134, 16, DateTime.Parse("2021.11.18"), "AMD", "AMD", "Ryzen 5", "RX 6500"),
                new Computer(35, 135, 32, DateTime.Parse("2022.08.13"), "Intel", "Nvidia", "i9", "RTX 3070 Ti"),
                new Computer(36, 136, 8, DateTime.Parse("2021.01.06"), "AMD", "none", "Athlon", "none"),
                new Computer(37, 137, 16, DateTime.Parse("2021.10.01"), "Intel", "AMD", "i5", "RX 6700"),
                new Computer(38, 138, 32, DateTime.Parse("2022.07.26"), "AMD", "Nvidia", "Ryzen 7", "RTX 3060"),
                new Computer(39, 139, 8, DateTime.Parse("2020.12.20"), "Intel", "none", "Pentium", "none"),
                new Computer(40, 140, 16, DateTime.Parse("2021.09.14"), "Intel", "AMD", "i5", "RX 6700"),
                new Computer(41, 141, 32, DateTime.Parse("2022.06.09"), "AMD", "Nvidia", "Ryzen 5", "RTX 2060"),
                new Computer(42, 142, 8, DateTime.Parse("2021.05.04"), "Intel", "none", "i3", "none"),
                new Computer(43, 143, 16, DateTime.Parse("2022.02.27"), "AMD", "AMD", "Ryzen 7", "RX 6700 XT"),
                new Computer(44, 144, 32, DateTime.Parse("2022.11.22"), "Intel", "Nvidia", "i9", "RTX 3080"),
                new Computer(45, 145, 8, DateTime.Parse("2021.04.17"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(46, 146, 16, DateTime.Parse("2022.01.10"), "Intel", "AMD", "i5", "RX 6600 XT"),
                new Computer(47, 147, 32, DateTime.Parse("2022.10.05"), "AMD", "Nvidia", "Ryzen 9", "RTX 3060 Ti"),
                new Computer(48, 148, 8, DateTime.Parse("2021.03.31"), "Intel", "none", "Celeron", "none"),
                new Computer(49, 149, 16, DateTime.Parse("2021.12.25"), "AMD", "AMD", "Ryzen 5", "RX 6800"),
                new Computer(50, 150, 32, DateTime.Parse("2022.09.19"), "Intel", "Nvidia", "i7", "RTX 3090")
            });
        }
    }
}
