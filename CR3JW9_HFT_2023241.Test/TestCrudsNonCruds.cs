using CR3JW9_HFT_2023241.Logic;
using CR3JW9_HFT_2023241.Models;
using CR3JW9_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Test
{
    [TestFixture]
    public class TestCrudsNonCruds
    {

        [Test] // GetOldestPersonPerJob
        public void GetOldestPersonPerJob()
        {
            JobLogic jobLogic;
            var repo = new Mock<IRepository<Job>>();
            jobLogic = new JobLogic(repo.Object);

            // Arrange
            int jobID = 50;
            repo.Setup(repo => repo.ReadAll()).Returns(new List<Job>
            {
                new Job
                {
                    JobID = jobID,
                    Persons = new List<Person>
                    {
                        new Person { Name = "Worker1", Age = 25 },
                        new Person { Name = "Worker2", Age = 30 },
                        new Person { Name = "Worker3", Age = 23 }
                    }
                }
            }.AsQueryable());

            // Act
            string result = jobLogic.GetOldestPersonPerJob(jobID);

            // Assert
            Assert.AreEqual("Worker2", result);
        }

        [Test] // GetYoungestPersonPerJob
        public void GetYoungestPersonPerJob()
        {
            JobLogic jobLogic;
            var repo = new Mock<IRepository<Job>>();
            jobLogic = new JobLogic(repo.Object);

            // Arrange
            int jobID = 50;
            repo.Setup(repo => repo.ReadAll()).Returns(new List<Job>
            {
                new Job
                {
                    JobID = jobID,
                    Persons = new List<Person>
                    {
                        new Person { Name = "Worker1", Age = 25 },
                        new Person { Name = "Worker2", Age = 30 },
                        new Person { Name = "Worker3", Age = 23 }
                    }
                }
            }.AsQueryable());

            // Act
            string result = jobLogic.GetYoungestPersonPerJob(jobID);

            // Assert
            Assert.AreEqual("Worker3", result);
        }

        [Test] // GetAverageAgePerJob
        public void GetAverageAgePerJob()
        {
            JobLogic jobLogic;
            var repo = new Mock<IRepository<Job>>();
            jobLogic = new JobLogic(repo.Object);

            // Arrange
            int jobID = 123;
            repo.Setup(repo => repo.ReadAll()).Returns(new List<Job>
            {
                new Job
                {
                JobID = 123,
                Persons = new List<Person>
                    {
                        new Person { Age = 25 },
                        new Person { Age = 30 },
                        new Person { Age = 35 }
                    }
                },
                new Job
                {
                JobID = 456,
                Persons = new List<Person>
                    {
                        new Person { Age = 20 },
                        new Person { Age = 22 }
                    }
                }
            }.AsQueryable());

            // Act
            double? result = jobLogic.GetAverageAgePerJob(jobID);

            // Assert
            Assert.AreEqual(30, result);
        }

        [Test] // GetNumberOfPeople
        public void GetNumberOfPeople()
        {
            // Arrange
            int jobID = 123;

            JobLogic jobLogic;
            var repo = new Mock<IRepository<Job>>();
            jobLogic = new JobLogic(repo.Object);

            repo.Setup(repo => repo.ReadAll()).Returns(new List<Job>
            {
                new Job
                {
                JobID = 123,
                Persons = new List<Person>
                    {
                        new Person { Age = 25 },
                        new Person { Age = 30 },
                        new Person { Age = 35 }
                    }
                },
                new Job
                {
                JobID = 456,
                Persons = new List<Person>
                    {
                        new Person { Age = 20 },
                        new Person { Age = 22 }
                    }
                }
            }.AsQueryable());

            // Act
            var numberOfPeople = jobLogic.GetNumberOfPeople(jobID);

            // Assert
            Assert.AreEqual(3, numberOfPeople);
        }

        [Test] // GetCPUModelByJobID
        public void GetCPUModelByJobID()
        {
            // Arrange
            int jobID = 225;

            PersonLogic personLogic;
            var repo = new Mock<IRepository<Person>>();
            personLogic = new PersonLogic(repo.Object);

            repo.Setup(repo => repo.ReadAll()).Returns(new List<Person>
        {
            new Person
            {
                JobID = 123,
                Computers = new List<Computer>
                {
                    new Computer { CPUModel = "Intel i7" },
                    new Computer { CPUModel = "AMD Ryzen 9" }
                }
            },
            new Person
            {
                JobID = 225,
                Computers = new List<Computer>
                {
                    new Computer { CPUModel = "Intel i5" },
                    new Computer { CPUModel = "AMD Ryzen 7" }
                }
            },
            new Person
            {
                JobID = 456,
                Computers = new List<Computer>
                {
                    new Computer { CPUModel = "AMD Ryzen 5" }
                }
            }
        }.AsQueryable());

            // Act
            var cpuModels = personLogic.GetCPUModelByJobID(jobID);

            // Assert

            Assert.AreEqual(new List<string> { "Intel i5", "AMD Ryzen 7" }, cpuModels.Select(t => t.CPUModel).ToList());
        }

        [Test] // GetNumberOfFastComputers
        public void GetNumberOfFastComputers()
        {
            // Arrange
            int jobID = 123; // Replace with the desired job ID

            ComputerLogic computerLogic;
            var repo = new Mock<IRepository<Computer>>();
            computerLogic = new ComputerLogic(repo.Object);

            repo.Setup(repo => repo.ReadAll()).Returns(new List<Computer>
        {
            new Computer { RAMAmount = 8, GPUModel = ""}, // Does not meet the criteria
            new Computer { RAMAmount = 16, GPUModel = "GTX 1660" }, // Meets the criteria
            new Computer { RAMAmount = 32, GPUModel = "RX 580" }, // Meets the criteria
            new Computer { RAMAmount = 16, GPUModel = "" }, // Does not meet the criteria
        }.AsQueryable());

            // Act
            var numberOfFastComputers = computerLogic.GetNumberOfFastComputers();

            // Assert
            Assert.AreEqual(2, numberOfFastComputers);
        }

        [Test] // GetOwnerOfComputerByComputerID
        public void GetOwnerOfComputerByComputerID()
        {
            // Arrange
            int computerID = 100;
            ComputerLogic computerLogic;
            var repo = new Mock<IRepository<Computer>>();
            computerLogic = new ComputerLogic(repo.Object);

            repo.Setup(repo => repo.ReadAll()).Returns(new List<Computer>
        {
            new Computer { ComputerID = 100, RAMAmount = 16, GPUModel = "GTX 1660", 
                Person = new Person { Name = "John Doe" } }, // Computer with valid criteria and owner
            new Computer { ComputerID = 200, RAMAmount = 8, GPUModel = "", 
                Person = new Person { Name = "Alice Smith" } }, // Computer without valid criteria
        }.AsQueryable());

            // Act
            var ownerName = computerLogic.GetOwnerOfComputerByComputerID(computerID);

            // Assert
            Assert.AreEqual("John Doe", ownerName);
        }

        [Test] // Testing Person creation
        public void PersonCreateTest()
        {
            // Arrange
            int personID = 1;
            int jobID = 123;
            string name = "John Doe";
            int age = 30;
            DateTime birthDate = DateTime.Parse("1992.11.15");
            DateTime worksSince = DateTime.Parse("2015.10.20");
            var computers = new List<Computer>
        {
            new Computer {},
            new Computer {}
        };
            var job = new Job { JobID = jobID };

            // Act
            var person = new Person
            {
                PersonID = personID,
                JobID = jobID,
                Name = name,
                Age = age,
                BirthDate = birthDate,
                WorksSince = worksSince,
                Computers = computers,
                Job = job
            };

            // Assert
            Assert.AreEqual(personID, person.PersonID);
            Assert.AreEqual(jobID, person.JobID);
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(age, person.Age);
            Assert.AreEqual(birthDate, person.BirthDate);
            Assert.AreEqual(worksSince, person.WorksSince);
            CollectionAssert.AreEqual(computers, person.Computers.ToList());
            Assert.AreEqual(job, person.Job);
        }

        [Test] // Testing Job creation
        public void JobCreateTest()
        {
            // Arrange
            int jobID = 100;
            string jobName = "Software Engineer";
            string jobLocation = "New York";
            int salary = 10000;
            var persons = new List<Person>
        {
            new Person { Name = "Worker1", Age = 30 },
            new Person { Name = "Worker2", Age = 28 }
        };

            // Act
            var job = new Job
            {
                JobID = jobID,
                JobName = jobName,
                JobLocation = jobLocation,
                Salary = salary,
                Persons = persons
            };

            // Assert
            Assert.AreEqual(jobID, job.JobID);
            Assert.AreEqual(jobName, job.JobName);
            Assert.AreEqual(jobLocation, job.JobLocation);
            Assert.AreEqual(salary, job.Salary);
            CollectionAssert.AreEqual(persons, job.Persons.ToList());
        }

        [Test] // Testing Computer creation
        public void ComputerCreateTest()
        {
            // Arrange
            int computerID = 1;
            int personID = 101;
            int ramAmount = 16;
            DateTime dateOfAssembly = DateTime.Parse("2005.11.12");
            string cpuManufacturer = "Intel";
            string gpuManufacturer = "NVIDIA";
            string cpuModel = "Intel i7";
            string gpuModel = "RTX 3080";

            // Act
            var computer = new Computer
            {
                ComputerID = computerID,
                PersonID = personID,
                RAMAmount = ramAmount,
                DateOfAssembly = dateOfAssembly,
                CPUManufacturer = cpuManufacturer,
                GPUManufacturer = gpuManufacturer,
                CPUModel = cpuModel,
                GPUModel = gpuModel
            };

            // Assert
            Assert.AreEqual(computerID, computer.ComputerID);
            Assert.AreEqual(personID, computer.PersonID);
            Assert.AreEqual(ramAmount, computer.RAMAmount);
            Assert.AreEqual(dateOfAssembly, computer.DateOfAssembly);
            Assert.AreEqual(cpuManufacturer, computer.CPUManufacturer);
            Assert.AreEqual(gpuManufacturer, computer.GPUManufacturer);
            Assert.AreEqual(cpuModel, computer.CPUModel);
            Assert.AreEqual(gpuModel, computer.GPUModel);
        }
    }
}
