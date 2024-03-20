using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class Goals
    {
         public int GoalID{get;set;}
         [Required(ErrorMessage ="This field is required")]
         [MaxLength(20,ErrorMessage ="Maximum length of characters is 20")]
         public string GoalType{get;set;}
         [DataType(DataType.Date,ErrorMessage ="Please enter date only")]
         public DateOnly TargetDate{get;set;} 
         public List<Exercises> exercises{get;set;}
         public MyWebApiProject.Models.Progress progress { get; set; } // Fully qualify Progress type

         public decimal ProgressValue => progress?.ProgressValue ?? 0;
    }
}