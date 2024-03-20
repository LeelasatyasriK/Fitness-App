using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.Models
{
    public class Progress
    {
        [Key]
        public int ProgressID{get;set;}
        public int GoalID{get;set;}
        
        [ForeignKey("GoalID")]
        public Goals goal{get;set;}
        public DateOnly Date{get;set;}
        public decimal ProgressValue{get;set;}
    }
}