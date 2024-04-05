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
    public class ComputerController : ControllerBase
    {
        IComputerLogic logic;
        IHubContext<SignalRHub> hub;
        public ComputerController(IComputerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Computer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Computer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Computer value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ComputerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Computer value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ComputerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var computerToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ComputerDeleted", computerToDelete);
        }
    }
}
