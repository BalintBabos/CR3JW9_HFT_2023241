using CR3JW9_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Dataset.mdf;Integrated Security=True;MultipleActiveResultSets=True";
                builder.UseSqlServer(conn).UseLazyLoadingProxies();

                //builder.UseInMemoryDatabase("workdb").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(
                 job => job.HasMany(job => job.Persons)
                                 .WithOne(job => job.Job)
                                 .HasForeignKey(job => job.JobID)
                                 .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Person>(
                person => person.HasOne<Job>()
                                .WithMany(job => job.Persons)
                                .HasForeignKey(person => person.JobID)
                                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Computer>(
                computer => computer.HasOne(computer => computer.Person)
                                .WithMany(person => person.Computers)
                                .HasForeignKey(computer => computer.PersonID)
                                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new Person(101, 220, "John Smith", 80, DateTime.Parse("1983.10.10"), DateTime.Parse("2010.05.05")),
                new Person(102, 170, "Claire White", 40, DateTime.Parse("1990.08.20"), DateTime.Parse("2018.12.01")),
                new Person(103, 270, "Tom Branford", 60, DateTime.Parse("1960.02.25"), DateTime.Parse("1997.08.13")),
                new Person(104, 230, "Emily Johnson", 80, DateTime.Parse("1987.06.15"), DateTime.Parse("2015.09.20")),
                new Person(105, 40, "Michael Smith", 100, DateTime.Parse("1978.03.28"), DateTime.Parse("2005.11.12")),
                new Person(106, 250, "Sophia Williams", 60, DateTime.Parse("1995.11.05"), DateTime.Parse("2020.04.03")),
                new Person(107, 210, "Daniel Brown", 70, DateTime.Parse("1972.09.10"), DateTime.Parse("2000.12.30")),
                new Person(108, 270, "Olivia Jones", 90, DateTime.Parse("1989.12.22"), DateTime.Parse("2016.07.18")),
                new Person(109, 290, "William Davis", 20, DateTime.Parse("1984.08.08"), DateTime.Parse("2011.12.05")),
                new Person(110, 120, "Ava Miller", 90, DateTime.Parse("1994.04.30"), DateTime.Parse("2019.10.22")),
                new Person(111, 290, "Aria Kelly", 100, DateTime.Parse("1992.11.15"), DateTime.Parse("2019.03.18")),
                new Person(112, 250, "Eli Turner", 80, DateTime.Parse("1983.12.08"), DateTime.Parse("2011.04.25")),
                new Person(113, 270, "Grace Cooper", 90, DateTime.Parse("1997.09.21"), DateTime.Parse("2024.01.14")),
                new Person(114, 110, "Mila Richardson", 80, DateTime.Parse("1981.05.24"), DateTime.Parse("2008.08.07")),
                new Person(115, 140, "Carter Wood", 90, DateTime.Parse("1985.02.17"), DateTime.Parse("2012.06.30")),
                new Person(116, 160, "Nova Brooks", 70, DateTime.Parse("1994.07.10"), DateTime.Parse("2021.10.23")),
                new Person(117, 240, "Grayson Watson", 40, DateTime.Parse("1978.03.03"), DateTime.Parse("2005.06.15")),
                new Person(118, 290, "Layla Morgan", 20, DateTime.Parse("1989.01.26"), DateTime.Parse("2016.04.09")),
                new Person(119, 70, "Zachary Price", 70, DateTime.Parse("1995.04.30"), DateTime.Parse("2022.08.02")),
                new Person(120, 150, "Riley Hughes", 10, DateTime.Parse("1987.08.12"), DateTime.Parse("2014.11.27")),
                new Person(121, 290, "Hannah Sanders", 90, DateTime.Parse("1992.06.25"), DateTime.Parse("2019.09.08")),
                new Person(122, 190, "Isaac Simmons", 40, DateTime.Parse("1980.10.18"), DateTime.Parse("2007.12.21")),
                new Person(123, 80, "Eleanor Patterson", 70, DateTime.Parse("1988.07.09"), DateTime.Parse("2015.10.04")),
                new Person(124, 220, "Nathan Perry", 100, DateTime.Parse("1996.12.12"), DateTime.Parse("2023.03.18")),
                new Person(125, 50, "Violet Foster", 70, DateTime.Parse("1979.11.05"), DateTime.Parse("2006.02.08")),
                new Person(126, 300, "Levi Henderson", 20, DateTime.Parse("1992.05.19"), DateTime.Parse("2019.08.22")),
                new Person(127, 150, "Addison Perry", 10, DateTime.Parse("1989.02.22"), DateTime.Parse("2016.05.05")),
                new Person(128, 230, "Elena Richardson", 30, DateTime.Parse("1995.07.05"), DateTime.Parse("2022.10.18")),
                new Person(129, 200, "Nicholas Hughes", 80, DateTime.Parse("1978.04.08"), DateTime.Parse("2005.07.31")),
                new Person(130, 250, "Skylar Carter", 60, DateTime.Parse("1984.03.21"), DateTime.Parse("2011.06.13")),
                new Person(131, 220, "Claire Gray", 50, DateTime.Parse("1988.01.14"), DateTime.Parse("2015.04.27")),
                new Person(132, 130, "Zander Watson", 40, DateTime.Parse("1997.12.27"), DateTime.Parse("2025.03.02")),
                new Person(133, 150, "Mackenzie Parker", 90, DateTime.Parse("1980.09.10"), DateTime.Parse("2008.12.23")),
                new Person(134, 140, "Isabelle Flores", 70, DateTime.Parse("1991.06.03"), DateTime.Parse("2018.09.06")),
                new Person(135, 80, "Eliana Morgan", 10, DateTime.Parse("1983.08.16"), DateTime.Parse("2010.11.29")),
                new Person(136, 170, "Gavin Adams", 50, DateTime.Parse("1996.02.09"), DateTime.Parse("2023.05.14")),
                new Person(137, 100, "Lily Wood", 80, DateTime.Parse("1979.05.22"), DateTime.Parse("2006.08.05")),
                new Person(138, 120, "Oscar Ramirez", 60, DateTime.Parse("1987.10.25"), DateTime.Parse("2014.01.17")),
                new Person(139, 300, "Hazel Martin", 90, DateTime.Parse("1977.07.28"), DateTime.Parse("2004.10.01")),
                new Person(140, 70, "Ivy Campbell", 50, DateTime.Parse("1985.04.01"), DateTime.Parse("2012.07.14")),
                new Person(141, 50, "Zander Watson", 80, DateTime.Parse("1997.12.27"), DateTime.Parse("2025.03.02")),
                new Person(142, 90, "Mackenzie Parker", 40, DateTime.Parse("1980.09.10"), DateTime.Parse("2008.12.23")),
                new Person(143, 130, "Isabelle Flores", 30, DateTime.Parse("1991.06.03"), DateTime.Parse("2018.09.06")),
                new Person(144, 270, "Eliana Morgan", 90, DateTime.Parse("1983.08.16"), DateTime.Parse("2010.11.29")),
                new Person(145, 80, "Gavin Adams", 50, DateTime.Parse("1996.02.09"), DateTime.Parse("2023.05.14")),
                new Person(146, 40, "Lily Wood", 80, DateTime.Parse("1979.05.22"), DateTime.Parse("2006.08.05")),
                new Person(147, 180, "Oscar Ramirez", 60, DateTime.Parse("1987.10.25"), DateTime.Parse("2014.01.17")),
                new Person(148, 190, "Hazel Martin", 90, DateTime.Parse("1977.07.28"), DateTime.Parse("2004.10.01")),
                new Person(149, 50, "Ivy Campbell", 50, DateTime.Parse("1985.04.01"), DateTime.Parse("2012.07.14")),
                new Person(150, 20, "Random Person", 40, DateTime.Parse("1990.01.01"), DateTime.Parse("2023.12.31"))

            });
            modelBuilder.Entity<Job>().HasData(new Job[]
            {
                new Job(10, "Software Engineer", "San Francisco", 9000),
                new Job(20, "Data Scientist", "Seattle", 9500),
                new Job(30, "UX/UI Designer", "New York", 8500),
                new Job(40, "Product Manager", "Los Angeles", 11000),
                new Job(50, "Cybersecurity Analyst", "Chicago", 10500),
                new Job(60, "Cloud Solutions Architect", "Austin", 10000),
                new Job(70, "Business Analyst", "Houston", 8500),
                new Job(80, "HR Manager", "Boston", 7500),
                new Job(90, "Marketing Specialist", "Denver", 8000),
                new Job(100, "AI/Machine Learning Engineer", "San Jose", 12000),
                new Job(110, "Network Administrator", "Dallas", 8500),
                new Job(120, "Financial Analyst", "San Diego", 9500),
                new Job(130, "Project Manager", "Washington D.C.", 10500),
                new Job(140, "Software Development Manager", "Philadelphia", 11000),
                new Job(150, "IT Support Specialist", "Phoenix", 7000),
                new Job(160, "Database Administrator", "Portland", 9000),
                new Job(170, "Quality Assurance Engineer", "Miami", 8000),
                new Job(180, "Systems Engineer", "Atlanta", 9500),
                new Job(190, "Technical Writer", "Orlando", 7500),
                new Job(200, "DevOps Engineer", "Las Vegas", 10000),
                new Job(210, "Product Marketing Manager", "Minneapolis", 10500),
                new Job(220, "Full Stack Developer", "Charlotte", 9500),
                new Job(230, "Sales Manager", "San Antonio", 11000),
                new Job(240, "UI/UX Researcher", "Detroit", 8500),
                new Job(250, "Customer Success Manager", "Raleigh", 9000),
                new Job(260, "Network Security Engineer", "Indianapolis", 10000),
                new Job(270, "Business Intelligence Analyst", "Salt Lake City", 8500),
                new Job(280, "Operations Manager", "Nashville", 9500),
                new Job(290, "Software QA Tester", "Tampa", 7500),
                new Job(300, "Systems Analyst", "Pittsburgh", 8500),
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
                new Computer(50, 150, 32, DateTime.Parse("2022.09.19"), "Intel", "Nvidia", "i7", "RTX 3090"),
                new Computer(51, 147, 16, DateTime.Parse("2022.06.05"), "AMD", "Nvidia", "Ryzen 7", "RTX 3060"),
                new Computer(52, 116, 32, DateTime.Parse("2023.04.18"), "Intel", "Nvidia", "i7", "RTX 3070"),
                new Computer(53, 125, 8, DateTime.Parse("2021.09.20"), "Intel", "none", "i5", "none"),
                new Computer(54, 133, 64, DateTime.Parse("2023.01.08"), "AMD", "AMD", "Ryzen 9", "RX 6900 XT"),
                new Computer(55, 136, 16, DateTime.Parse("2022.11.30"), "Intel", "Nvidia", "i5", "GTX 1660 Ti"),
                new Computer(56, 106, 8, DateTime.Parse("2023.02.25"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(57, 138, 32, DateTime.Parse("2021.12.22"), "Intel", "Nvidia", "i7", "RTX 3080"),
                new Computer(58, 111, 16, DateTime.Parse("2023.07.14"), "AMD", "Nvidia", "Ryzen 7", "RTX 3060"),
                new Computer(59, 123, 8, DateTime.Parse("2022.08.10"), "Intel", "none", "i3", "none"),
                new Computer(60, 142, 32, DateTime.Parse("2022.05.03"), "AMD", "Nvidia", "Ryzen 5", "RTX 3070"),
                new Computer(61, 127, 16, DateTime.Parse("2023.01.28"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(62, 115, 4, DateTime.Parse("2022.04.19"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(63, 104, 64, DateTime.Parse("2022.12.17"), "Intel", "AMD", "i7", "RX 6800 XT"),
                new Computer(64, 143, 16, DateTime.Parse("2023.10.12"), "AMD", "Nvidia", "Ryzen 7", "RTX 3080"),
                new Computer(65, 110, 8, DateTime.Parse("2022.10.09"), "Intel", "none", "i5", "none"),
                new Computer(66, 134, 32, DateTime.Parse("2022.06.25"), "AMD", "Nvidia", "Ryzen 9", "RTX 3060 Ti"),
                new Computer(67, 124, 16, DateTime.Parse("2023.04.08"), "Intel", "Nvidia", "i7", "RTX 3070"),
                new Computer(68, 148, 8, DateTime.Parse("2022.02.14"), "AMD", "none", "Ryzen 5", "none"),
                new Computer(69, 131, 32, DateTime.Parse("2023.01.19"), "Intel", "Nvidia", "i9", "RTX 3080"),
                new Computer(70, 113, 16, DateTime.Parse("2022.09.07"), "AMD", "Nvidia", "Ryzen 7", "RTX 3070"),
                new Computer(71, 145, 8, DateTime.Parse("2023.08.02"), "Intel", "none", "i5", "none"),
                new Computer(72, 118, 32, DateTime.Parse("2022.07.29"), "AMD", "Nvidia", "Ryzen 9", "RTX 3080"),
                new Computer(73, 150, 16, DateTime.Parse("2023.03.14"), "Intel", "Nvidia", "i7", "RTX 3080"),
                new Computer(74, 101, 8, DateTime.Parse("2022.12.28"), "AMD", "none", "Ryzen 3", "none"),
                new Computer(75, 129, 32, DateTime.Parse("2023.10.23"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(76, 121, 16, DateTime.Parse("2022.11.15"), "AMD", "Nvidia", "Ryzen 5", "RTX 3060"),
                new Computer(77, 137, 8, DateTime.Parse("2023.09.10"), "Intel", "none", "i5", "none"),
                new Computer(78, 149, 32, DateTime.Parse("2022.05.27"), "AMD", "Nvidia", "Ryzen 9", "RTX 3070"),
                new Computer(79, 103, 16, DateTime.Parse("2023.01.03"), "Intel", "Nvidia", "i7", "RTX 3080"),
                new Computer(80, 146, 8, DateTime.Parse("2022.08.22"), "AMD", "none", "Ryzen 7", "none"),
                new Computer(81, 139, 32, DateTime.Parse("2023.07.18"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(82, 114, 16, DateTime.Parse("2022.06.12"), "AMD", "Nvidia", "Ryzen 5", "RTX 3060"),
                new Computer(83, 144, 8, DateTime.Parse("2023.04.07"), "Intel", "none", "i5", "none"),
                new Computer(84, 135, 32, DateTime.Parse("2022.12.01"), "AMD", "Nvidia", "Ryzen 9", "RTX 3080"),
                new Computer(85, 112, 16, DateTime.Parse("2022.09.25"), "Intel", "Nvidia", "i7", "RTX 3080"),
                new Computer(86, 141, 8, DateTime.Parse("2023.08.20"), "AMD", "none", "Ryzen 7", "none"),
                new Computer(87, 132, 32, DateTime.Parse("2022.04.18"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(88, 122, 16, DateTime.Parse("2022.03.09"), "AMD", "Nvidia", "Ryzen 5", "RTX 3060"),
                new Computer(89, 140, 8, DateTime.Parse("2023.01.25"), "Intel", "none", "i5", "none"),
                new Computer(90, 128, 32, DateTime.Parse("2022.11.21"), "AMD", "Nvidia", "Ryzen 9", "RTX 3070"),
                new Computer(91, 120, 16, DateTime.Parse("2023.09.14"), "Intel", "Nvidia", "i7", "RTX 3080"),
                new Computer(92, 130, 8, DateTime.Parse("2022.08.06"), "AMD", "none", "Ryzen 7", "none"),
                new Computer(93, 119, 32, DateTime.Parse("2023.06.30"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(94, 126, 16, DateTime.Parse("2022.05.24"), "AMD", "Nvidia", "Ryzen 5", "RTX 3060"),
                new Computer(95, 105, 8, DateTime.Parse("2023.02.11"), "Intel", "none", "i5", "none"),
                new Computer(96, 148, 32, DateTime.Parse("2022.12.04"), "AMD", "Nvidia", "Ryzen 9", "RTX 3080"),
                new Computer(97, 117, 16, DateTime.Parse("2023.10.27"), "Intel", "Nvidia", "i7", "RTX 3080"),
                new Computer(98, 147, 8, DateTime.Parse("2022.07.17"), "AMD", "none", "Ryzen 7", "none"),
                new Computer(99, 118, 32, DateTime.Parse("2022.04.13"), "Intel", "Nvidia", "i9", "RTX 3090"),
                new Computer(100, 150, 16, DateTime.Parse("2023.01.08"), "AMD", "Nvidia", "Ryzen 5", "RTX 3060")

            });
        }
    }
}
