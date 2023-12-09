using CR3JW9_HFT_2023241.Models;
using System;
using System.Linq;
using ConsoleTools;
using System.Collections.Generic;
using System.Data;
using System.Numerics;

namespace CR3JW9_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void GetComputerSpecsByJobID()
        {
            Console.WriteLine("Enter a Job's ID: ");
            int jobID = int.Parse(Console.ReadLine());

            var cpus = rest.GetComputerSpecsByJobID(jobID);
            Console.WriteLine($"The specifications of PCs for the job with jobID {jobID}:\n");
            foreach (var item in cpus)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        static void GetOldestPersonPerJob()
        {
            Console.WriteLine("Enter a Job's ID: ");
            int jobID = int.Parse(Console.ReadLine());

            var oldest = rest.GetOldestPersonPerJob(jobID);
            Console.WriteLine($"The oldest person with jobID {jobID}:\n");
            Console.WriteLine(oldest);
            Console.ReadLine();
        }

        static void GetYoungestPersonPerJob()
        {
            Console.WriteLine("Enter a Job's ID: ");
            int jobID = int.Parse(Console.ReadLine());

            var oldest = rest.GetYoungestPersonPerJob(jobID);
            Console.WriteLine($"The youngest person with jobID {jobID}:\n");
            Console.WriteLine(oldest);
            Console.ReadLine();
        }

        static void GetAverageAgePerJob()
        {
            Console.WriteLine("Enter a Job's ID: ");
            int jobID = int.Parse(Console.ReadLine());

            var average = rest.GetAverageAgePerJob(jobID);
            Console.WriteLine($"The average age of people with jobID {jobID}:\n");
            Console.WriteLine(average);
            Console.ReadLine();
        }

        static void GetNumberOfPeople()
        {
            Console.WriteLine("Enter a Job's ID: ");
            int jobID = int.Parse(Console.ReadLine());

            var number = rest.GetNumberOfPeople(jobID);
            Console.WriteLine($"The number of people with jobID {jobID}:\n");
            Console.WriteLine(number);
            Console.ReadLine();
        }

        static void GetOwnerOfComputerByComputerID()
        {
            Console.WriteLine("Enter a Computer's ID: ");
            int computerID = int.Parse(Console.ReadLine());

            var owner = rest.GetOwnerOfComputerByComputerID(computerID);
            Console.WriteLine($"The owner of the computer with computerID {computerID}:\n");
            Console.WriteLine(owner);
            Console.ReadLine();
        }

        static void GetNumberOfFastComputers()
        {
            var number = rest.GetNumberOfFastComputers();
            Console.WriteLine($"The number of fast computers:\n");
            Console.WriteLine(number);
            Console.ReadLine();
        }

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
                rest.Post(new Computer() { ComputerID = id }, "computer");
            }
        }
        static void ReadAll(string entity)
        {
            if (entity == "Person")
            {
                List<Person> people = rest.Get<Person>("person");
                foreach (var item in people)
                {
                    Console.WriteLine(item.PersonID + ": " + item.Name);
                }
                Console.ReadLine();
            }
            if (entity == "Job")
            {
                List<Job> jobs = rest.Get<Job>("job");
                foreach (var item in jobs)
                {
                    Console.WriteLine(item.JobID + ": " + item.JobName);
                }
                Console.ReadLine();
            }
            if (entity == "Computer")
            {
                List<Computer> computers = rest.Get<Computer>("computer");
                foreach (var item in computers)
                {
                    Console.WriteLine(item.ComputerID + ": " + item.DateOfAssembly);
                }
                Console.ReadLine();
            }
        }

        static void Read(string entity)
        {
            if (entity == "Person")
            {
                Console.Write("Enter Person's ID to read: ");
                int id = int.Parse(Console.ReadLine());
                Person person = rest.Get<Person>(id, "Person");
                Console.WriteLine($"Name: {person.Name}|| JobID: {person.JobID} || Age: {person.Age}");
            }
            else if (entity == "Job")
            {
                Console.Write("Enter Job's ID to read: ");
                int id = int.Parse(Console.ReadLine());
                Job job = rest.Get<Job>(id, "Job");
                Console.WriteLine($"Name: {job.JobName}|| JobID: {job.JobID} || Location: {job.JobLocation}");
            }
            else if (entity == "Computer")
            {
                Console.Write("Enter Computer's ID to read: ");
                int id = int.Parse(Console.ReadLine());
                Computer computer = rest.Get<Computer>(id, "Team");
                Console.WriteLine($"ID: {computer.ComputerID}|| Date of assembly: {computer.DateOfAssembly}");
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Person")
            {
                Console.Write("Enter Person's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Person one = rest.Get<Person>(id, "Person");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Person");
            }
            if (entity == "Job")
            {
                Console.Write("Enter Job's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Job one = rest.Get<Job>(id, "Job");
                Console.Write($"New name [old: {one.JobName}]: ");
                string name = Console.ReadLine();
                one.JobName = name;
                rest.Put(one, "Job");
            }
            if (entity == "Computer")
            {
                Console.Write("Enter Computer's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Computer one = rest.Get<Computer>(id, "Computer");
                Console.Write($"New Date of Assembly [old: {one.DateOfAssembly}]: ");
                DateTime dateOfAssembly = DateTime.Parse(Console.ReadLine());
                one.DateOfAssembly = dateOfAssembly;
                rest.Put(one, "Computer");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Person")
            {
                Console.Write("Enter Person's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Person");
            }
            if (entity == "Job")
            {
                Console.Write("Enter Job's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Job");
            }
            if (entity == "Computer")
            {
                Console.Write("Enter Computer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Computer");
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:59537/");
            var jobsSubMenu = new ConsoleMenu(args, level: 1)
               .Add("ReadAll", () => ReadAll("Job"))
               .Add("Read", () => Read("Job"))
               .Add("Create", () => Create("Job"))
               .Add("Delete", () => Delete("Job"))
               .Add("Update", () => Update("Job"))
               .Add("Exit", ConsoleMenu.Close);

            var computerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Computer"))
                .Add("Read", () => Read("Computer"))
                .Add("Create", () => Create("Computer"))
                .Add("Delete", () => Delete("Computer"))
                .Add("Update", () => Update("Computer"))
                .Add("Exit", ConsoleMenu.Close);

            var peopleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Person"))
                .Add("Read", () => Read("Person"))
                .Add("Create", () => Create("Person"))
                .Add("Delete", () => Delete("Person"))
                .Add("Update", () => Update("Person"))
                .Add("Exit", ConsoleMenu.Close);

            var nonCrudsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetComputerSpecsByJobID", () => GetComputerSpecsByJobID())
                .Add("GetOldestPersonPerJob", () => GetOldestPersonPerJob())
                .Add("GetYoungestPersonPerJob", () => GetYoungestPersonPerJob())
                .Add("GetAverageAgePerJob", () => GetAverageAgePerJob())
                .Add("GetNumberOfPeople", () => GetNumberOfPeople())
                .Add("GetOwnerOfComputerByComputerID", () => GetOwnerOfComputerByComputerID())
                .Add("GetNumberOfFastComputers", () => GetNumberOfFastComputers())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("People", () => peopleSubMenu.Show())
                .Add("Jobs", () => jobsSubMenu.Show())
                .Add("Computers", () => computerSubMenu.Show())
                .Add("Non-CRUDS", () => nonCrudsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}