using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class UpdateProgressDto
    {
        public int GoalID{get;set;}
        public DateOnly Date{get;set;}
        public decimal ProgressValue{get;set;}
    }
}