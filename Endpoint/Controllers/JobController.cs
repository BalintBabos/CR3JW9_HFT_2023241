using CR3JW9_HFT_2023241.Endpoint.Services;
using CR3JW9_HFT_2023241.Logic;
using CR3JW9_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CR3JW9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        IJobLogic logic;
        IHubContext<SignalRHub> hub;
        public JobController(IJobLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("JobCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Job value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("JobUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var jobToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("JobDeleted", jobToDelete);
        }
    }
}
