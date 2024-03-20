using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace MyWebApiProject.Models
{
    public class Goals
    {
        [Key]
        public int GoalID{get;set;}
        public string GoalType{get;set;}
        public DateOnly TargetDate{get;set;} 
        public List<Exercises> exercises{get;set;}
        public Progress progress{get;set;}
    }
}