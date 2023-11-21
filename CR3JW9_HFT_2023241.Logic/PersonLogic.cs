using CR3JW9_HFT_2023241.Models;
using CR3JW9_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Logic
{
    public class PersonLogic
    {
        IRepository<Person> repo;

        public PersonLogic(IRepository<Person> repo)
        {
            this.repo = repo;
        }

        public void Create(Person item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Person Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Person> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Person item)
        {
            this.repo.Update(item);
        }
        // non-cruds

        public IEnumerable<Computer> GetCPUModelByJobID(int jobID)
        {      
        var result = this.repo.ReadAll()
        .Where(t => t.JobID == jobID)
        .SelectMany(t => t.Computers);
        return result;
        }
    }
}
