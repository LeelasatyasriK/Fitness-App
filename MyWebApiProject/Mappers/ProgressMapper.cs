using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;
using MyWebApiProject.Models;

namespace MyWebApiProject.Mappers
{
    public static class ProgressMapper
    {
        public static DTOs.Progress ToProgressDto(this Models.Progress progress)
        {
            return new DTOs.Progress{
                ProgressID = progress.ProgressID,
                GoalID = progress.GoalID,
                Date = progress.Date,
                ProgressValue = progress.ProgressValue
            };
        }
        public static Models.Progress ToCreatePrgress(this CreateProgressDto createProgress)
        {
            return new Models.Progress
            {
                GoalID = createProgress.GoalID,
                Date = createProgress.Date,
                ProgressValue = createProgress.ProgressValue
            };
        }
    }
}