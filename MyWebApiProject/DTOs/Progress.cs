using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class Progress
    { public int ProgressID{get;set;}
        public int GoalID{get;set;}
        
        //[ForeignKey("GoalID")]
        public Goals goal{get;set;}
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Date,ErrorMessage ="Please enter date only")]
        public DateOnly Date{get;set;}
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid decimal value")]
        [Range(0, 100, ErrorMessage = "Calories burned per minute must be between 0 and 100")]
        public decimal ProgressValue{get;set;}
    }
}