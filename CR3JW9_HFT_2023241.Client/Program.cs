using CR3JW9_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;

namespace CR3JW9_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkDbContext ctx = new WorkDbContext();
            var workers = ctx.Persons;
            var jobs = ctx.Jobs;
            var computers = ctx.Computers;
            foreach (var item in workers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            foreach (var item in jobs)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            foreach (var item in computers)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
