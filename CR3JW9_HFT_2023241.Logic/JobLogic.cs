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
    public class JobLogic :IJobLogic
    {
        IRepository<Job> repo;

        public JobLogic(IRepository<Job> repo)
        {
            this.repo = repo;
        }

        public void Create(Job item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var job = repo.Read(id);
            if (job == null)
            {
                throw new ArgumentException();
            }
            repo.Delete(id);
        }

        public Job Read(int id)
        {
            var job = repo.Read(id);
            if (job == null)
            {
                throw new ArgumentException();
            }
            return repo.Read(id);
        }

        public IQueryable<Job> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Job item)
        {
            repo.Update(item);
        }

        // non-cruds
        public Person GetOldestPersonPerJob(int jobID)
        {
            var result1 =
               ReadAll().FirstOrDefault(t => t.JobID == jobID);
            var result2 = result1.Persons.OrderByDescending(t => t.Age).First();
            return result2;
        }
        public Person GetYoungestPersonPerJob(int jobID)
        {
            var result1 =
               ReadAll().FirstOrDefault(t => t.JobID == jobID);
            var result2 = result1.Persons.OrderBy(t => t.Age).First();
            return result2;
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
