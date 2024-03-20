using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;
using MyWebApiProject.Models;

namespace MyWebApiProject.Mappers
{
    public static class ExerciseMapper
    {
        public static DTOs.Exercises ToExcersiseDTO(this Models.Exercises exercises)
        {
            return new DTOs.Exercises
            {
                ExerciseID = exercises.ExerciseID,
                ExerciseName = exercises.ExerciseName,
                CaloriesBurnedPerMinute = exercises.CaloriesBurnedPerMinute,
                Duration = exercises.Duration,
                WorkoutID = exercises.WorkoutID
            };
        }
        public static Models.Exercises ToCreateExerciseDto(this CreateExerciseDto exerciseDto){
            return new Models.Exercises
            {
                ExerciseName = exerciseDto.ExerciseName,
                CaloriesBurnedPerMinute = exerciseDto.CaloriesBurnedPerMinute,
                Duration = exerciseDto.Duration,
                WorkoutID = exerciseDto.WorkoutID
            };
        }
    }
}