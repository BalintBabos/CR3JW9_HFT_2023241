using CR3JW9_HFT_2023241.Models;
using System;
using System.Linq;
using ConsoleTools;
using System.Collections.Generic;

namespace CR3JW9_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Person")
            {
                Console.Write("Enter Person Name: ");
                string name = Console.ReadLine();
                rest.Post(new Person() { Name = name }, "person");
            }
            if (entity == "Job")
            {
                Console.Write("Enter Job Name: ");
                string name = Console.ReadLine();
                rest.Post(new Job() { JobName = name }, "job");
            }
            if (entity == "Computer")
            {
                Console.Write("Enter Computer ID: ");
                int id = int.Parse(Console.ReadLine());
                rest.Post(new Computer() {ComputerID = id }, "computer");
            }
        }
        static void List(string entity)
        {
            if (entity == "Person")
            {
                List<Person> people = rest.Get<Person>("person");
                foreach (var item in people)
                {
                    Console.WriteLine(item.PersonID + ": " + item.Name);
                }
            }
            if (entity == "Job")
            {
                List<Job> jobs = rest.Get<Job>("job");
                foreach (var item in jobs)
                {
                    Console.WriteLine(item.JobID + ": " + item.JobName);
                }
            }
            if (entity == "Computer")
            {
                List<Computer> computers = rest.Get<Computer>("computer");
                foreach (var item in computers)
                {
                    Console.WriteLine(item.ComputerID + ": " + item.DateOfAssembly);
                }
            }
        }
        static void Update(string entity)
        {
            if (entity == "Person")
            {
                Console.Write("Enter Person's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Person one = rest.Get<Person>(id, "person");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "person");
            }
            if (entity == "Person")
            {
                Console.Write("Enter Person's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Person one = rest.Get<Person>(id, "person");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "person");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Person")
            {
                Console.Write("Enter Person's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "person");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("he?");
            rest = new RestService("http://localhost:59537/");
            Console.WriteLine("he2?");
            Console.Read();
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
