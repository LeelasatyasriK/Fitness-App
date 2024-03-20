using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class UpdateExerciseDto
    {
         public string ExerciseName{get;set;}
        public int CaloriesBurnedPerMinute{get;set;}
        public int Duration{get; set;}
        public int? WorkoutID{get;set;}
    }
}