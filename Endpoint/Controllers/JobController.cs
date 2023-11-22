using CR3JW9_HFT_2023241.Logic;
using CR3JW9_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CR3JW9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        IJobLogic logic;
        public JobController(IJobLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Job> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Job Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Job value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Job value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
