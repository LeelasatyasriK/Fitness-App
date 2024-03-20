using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;
using MyWebApiProject.Models;

namespace MyWebApiProject.Mappers
{
    public static class GoalsMapper
    {
        public static DTOs.Goals ToGoalsDto(this Models.Goals goals)
        {
            return new DTOs.Goals{
                GoalID = goals.GoalID,
                GoalType = goals.GoalType,
                TargetDate = goals.TargetDate,
                exercises = goals.exercises.Select(e => e.ToExcersiseDTO()).ToList()
                //progress = goals.progress.
            };
        }
        public static Models.Goals ToCreateGoalsDto(this CreateGoalDto createGoal)
        {
            return new Models.Goals
            {
                GoalType = createGoal.GoalType,
                TargetDate = createGoal.TargetDate
            };
        }
    }
}