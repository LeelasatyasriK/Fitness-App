using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class UpdateGoalDto
    {
          public string GoalType{get;set;}
        public DateOnly TargetDate{get;set;} 
    }
}