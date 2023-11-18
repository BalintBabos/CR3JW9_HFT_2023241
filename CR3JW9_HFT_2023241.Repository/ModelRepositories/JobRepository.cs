using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Repository.ModelRepositories
{
    public class JobRepository : Repository<Job>, IRepository<Job>
    {
        public JobRepository(WorkDbContext ctx) : base(ctx)
        {
        }

        public override Job Read(int id)
        {
            return ctx.Jobs.FirstOrDefault(t => t.JobID == id);
        }

        public override void Update(Job item)
        {
            var old = Read(item.JobID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
