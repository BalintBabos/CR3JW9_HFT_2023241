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
    public class ComputerLogic : IComputerLogic
    {
        IRepository<Computer> repo;

        public ComputerLogic(IRepository<Computer> repo)
        {
            this.repo = repo;
        }

        public void Create(Computer item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Computer Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Computer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Computer item)
        {
            this.repo.Update(item);
        }

        // non-cruds
        public int? GetNumberOfFastComputers() // has GPU & RAM >16
        {
            var result = this.repo.ReadAll().Where(c => c.RAMAmount >= 16 && !string.IsNullOrEmpty(c.GPUModel)).Count();
            return result;
        }

        public string? GetOwnerOfComputerByComputerID(int computerID)
        {
            var result = this.repo.ReadAll()
        .Where(c => c.ComputerID == computerID)
        .Select(c => c.Person.Name)
        .FirstOrDefault();
            return result;
        }
    }
}
