using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.Models
{
    public class Exercises
    {
        [Key]
        public int ExerciseID{get;set;}
        public string ExerciseName{get;set;} = string.Empty;
        public int CaloriesBurnedPerMinute{get;set;}
        public int Duration{get; set;}
        public int? WorkoutID{get;set;}
        [ForeignKey("WorkoutID")]
        public Workouts workout{get;set;}
        public List<Goals> goals{get;set;}
    }
}