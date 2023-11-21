using CR3JW9_HFT_2023241.Models;
using CR3JW9_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Logic
{
    public class JobLogic
    {
        IRepository<Job> repo;

        public JobLogic(IRepository<Job> repo)
        {
            this.repo = repo;
        }

        public void Create(Job item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Job Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Job> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Job item)
        {
            this.repo.Update(item);
        }

        // non-cruds
        public string? GetOldestPersonPerJob(int jobID)
        {
            var result1 =
               ReadAll().FirstOrDefault(t => t.JobID == jobID);
            var result2 = result1.Persons.OrderByDescending(t => t.Age).First();
            return result2.Name;
        }
        public string? GetYoungestPersonPerJob(int jobID)
        {
            var result1 =
               ReadAll().FirstOrDefault(t => t.JobID == jobID);
            var result2 = result1.Persons.OrderBy(t => t.Age).First();
            return result2.Name;
        }

        public double? GetAverageAgePerJob(int jobID)
        {
            var result = ReadAll().FirstOrDefault(t => t.JobID == jobID);
            return result.Persons.Average(t => t.Age);
        }

        public int? GetNumberOfPeople(int jobID)
        {
            var result = this.repo.ReadAll().Include(t => t.Persons).Where(t => t.JobID == jobID).Select(t => t.Persons.Count()).FirstOrDefault();
            return result;
        }
    }
}
