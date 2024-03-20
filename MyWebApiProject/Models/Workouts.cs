using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.Models
{
    public class Workouts
    {
        [Key]
        public int WorkoutID{get;set;}
        public DateOnly Date{get;set;}
        public int CaloriesBurned{get;set;}
        public List<Exercises> exercise{get;set;}
        
        
    }
}