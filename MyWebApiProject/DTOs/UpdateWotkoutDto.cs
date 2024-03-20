using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class UpdateWotkoutDto
    {
          public DateOnly Date{get;set;}
        public int CaloriesBurned{get;set;}
    }
}