﻿using Microsoft.AspNetCore.Mvc;
using CR3JW9_HFT_2023241.Logic;
using System.Collections.Generic;
using CR3JW9_HFT_2023241.Models;

namespace CR3JW9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPersonLogic personLogic;
        IJobLogic jobLogic;
        IComputerLogic computerLogic;

        public StatController(IPersonLogic personLogic, IJobLogic jobLogic, IComputerLogic computerLogic)
        {
            this.personLogic = personLogic;
            this.jobLogic = jobLogic;        
            this.computerLogic = computerLogic;
        }

        [HttpGet("{jobID}")]
        public IEnumerable<Computer> GetComputerSpecsByJobID(int jobID)
        {
            return this.personLogic.GetComputerSpecsByJobID(jobID);
        }

        [HttpGet("{jobID}")]
        public string? GetOldestPersonPerJob(int jobID)
        {
            return this.jobLogic.GetOldestPersonPerJob(jobID);
        }
        [HttpGet("{jobID}")]
        public string? GetYoungestPersonPerJob(int jobID)
        {
            return this.jobLogic.GetYoungestPersonPerJob(jobID);
        }

        [HttpGet("{jobID}")]
        public double? GetAverageAgePerJob(int jobID)
        {
            return this.jobLogic.GetAverageAgePerJob(jobID);
        }

        [HttpGet("{jobID}")]
        public int? GetNumberOfPeople(int jobID)
        {
            return this.jobLogic.GetNumberOfPeople(jobID);
        }

        [HttpGet]
        public int? GetNumberOfFastComputers()
        {
            return this.computerLogic.GetNumberOfFastComputers();
        }

        [HttpGet("{computerID}")]
        public string? GetOwnerOfComputerByComputerID(int computerID)
        {
            return this.computerLogic.GetOwnerOfComputerByComputerID(computerID);
        }

    }
}
