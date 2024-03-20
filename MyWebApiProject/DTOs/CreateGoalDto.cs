using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class CreateGoalDto
    {
         [Required(ErrorMessage ="This field is required")]
         [MaxLength(20,ErrorMessage ="Maximum length of characters is 20")]
        public string GoalType{get;set;}
         [DataType(DataType.Date,ErrorMessage ="Please enter date only")]
        public DateOnly TargetDate{get;set;} 
    }
}