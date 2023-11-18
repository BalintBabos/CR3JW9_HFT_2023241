using CR3JW9_HFT_2023241.Repository;
using CR3JW9_HFT_2023241.Logic;
using CR3JW9_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Linq;
using CR3JW9_HFT_2023241.Repository.ModelRepositories;
using ConsoleTools;

namespace CR3JW9_HFT_2023241.Client
{
    internal class Program
    {
        static PersonLogic personLogic;
        static JobLogic jobLogic;
        static ComputerLogic computerLogic;

        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Person")
            {
                var items = personLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.PersonID + "\t" + item.Name);
                }
            }
            else if (entity == "Job")
            {
                var items = jobLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.JobID + "\t" + item.JobName);
                }
            }
            else if (entity == "Computer")
            {
                var items = computerLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ComputerID + "\t" + item.PersonID);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var ctx = new WorkDbContext();

            var personRepo = new PersonRepository(ctx);
            var jobRepo = new JobRepository(ctx);
            var computerRepo = new ComputerRepository(ctx);

            personLogic = new PersonLogic(personRepo);
            jobLogic = new JobLogic(jobRepo);
            computerLogic = new ComputerLogic(computerRepo);

            //var workers = ctx.Persons;
            //var jobs = ctx.Jobs;
            //var computers = ctx.Computers;
            //foreach (var item in workers)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine();
            //foreach (var item in jobs)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine();
            //foreach (var item in computers)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //var a = ctx.Persons.ToArray();
            //var b = ctx.Jobs.ToArray();
            //var c = ctx.Computers.ToArray();

            var jobsSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Job"))
               .Add("Create", () => Create("Job"))
               .Add("Delete", () => Delete("Job"))
               .Add("Update", () => Update("Job"))
               .Add("Exit", ConsoleMenu.Close);

            var computerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Computer"))
                .Add("Create", () => Create("Computer"))
                .Add("Delete", () => Delete("Computer"))
                .Add("Update", () => Update("Computer"))
                .Add("Exit", ConsoleMenu.Close);

            var peopleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Person"))
                .Add("Create", () => Create("Person"))
                .Add("Delete", () => Delete("Person"))
                .Add("Update", () => Update("Person"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("People", () => peopleSubMenu.Show())
                .Add("Jobs", () => jobsSubMenu.Show())
                .Add("Computers", () => computerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
