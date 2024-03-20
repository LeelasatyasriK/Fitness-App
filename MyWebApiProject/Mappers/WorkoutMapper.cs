using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyWebApiProject.DTOs;
using MyWebApiProject.Models;

namespace MyWebApiProject.Mappers
{
    public static class WorkoutMapper
    {
        public static DTOs.Workouts ToWorkoutDTO(this Models.Workouts workouts)
        {
            return new DTOs.Workouts
            {
                WorkoutID = workouts.WorkoutID,
                Date = workouts.Date,
                CaloriesBurned = workouts.CaloriesBurned,
                exercise = workouts.exercise.Select(e => e.ToExcersiseDTO()).ToList()
            };
        }
        public static Models.Workouts ToWorkoutCreateDto(this CreateWorkoutRequestDto workout)
        {
            return new Models.Workouts
            {
                Date = workout.Date,
                CaloriesBurned = workout.CaloriesBurned
            };
        }
    }
}