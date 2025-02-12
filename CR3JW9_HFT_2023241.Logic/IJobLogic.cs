﻿using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Logic
{
    public interface IJobLogic
    {
        void Create(Job item);
        void Delete(int id);
        Job Read(int id);
        IQueryable<Job> ReadAll();
        void Update(Job item);
        Person GetOldestPersonPerJob(int jobID);
        Person GetYoungestPersonPerJob(int jobID);

        double? GetAverageAgePerJob(int jobID);
        int? GetNumberOfPeople(int jobID);
    }
}
