using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class CreateWorkoutRequestDto
    {
        // public int WorkoutID{get;set;}
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Date,ErrorMessage ="Please enter date only")]
        public DateOnly Date{get;set;}
        [Required(ErrorMessage ="This field is required")]
        [Range(0, 10000, ErrorMessage = "Calories burned per minute must be between 0 and 10,000")]
        public int CaloriesBurned{get;set;}
       
    }
}