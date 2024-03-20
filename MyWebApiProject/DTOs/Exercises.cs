using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class Exercises
    {
         public int ExerciseID{get;set;}

        [Required(ErrorMessage ="This field is required")]
        [MaxLength(20,ErrorMessage ="Maximum length of characters is 20")]
        public string ExerciseName{get;set;} = string.Empty;

        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid integer value")]
        [Range(0, 1000, ErrorMessage = "Calories burned per minute must be between 0 and 1000")]
        public int CaloriesBurnedPerMinute{get;set;}
        public int Duration{get; set;}
        public int? WorkoutID{get;set;}
       // public Workouts workout{get;set;}
       // public List<Goals> goals{get;set;}
    }
}