using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Data;
using MyWebApiProject.DTOs;
using MyWebApiProject.Interfaces;

namespace MyWebApiProject.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {

        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
           _context = context;   
        }
        public async Task<Models.Exercises> CreateExerciseAsync(Models.Exercises exercise)
        {
            await _context.exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<Models.Exercises?> DeleteExerciseAsync(int id)
        {
            var exercise = await _context.exercises.FirstOrDefaultAsync(e => e.ExerciseID ==id);

            if(exercise == null)
            {
                return null;
            }
            _context.exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<List<Models.Exercises>> GetAllExercisesAsync()
        {
             return await _context.exercises.ToListAsync();
        }

        public async Task<Models.Exercises?> GetExerciseByIdAsync(int id)
        {
            return await _context.exercises.FindAsync(id);
        }

        public async Task<Models.Exercises?> UpdateExerciseAsync(int id, UpdateExerciseDto exerciseDto)
        {
            var existingExercise = await _context.exercises.FirstOrDefaultAsync(e => e.ExerciseID == id);

            if(existingExercise == null)
            {
                return null;
            }

            existingExercise.ExerciseName = exerciseDto.ExerciseName;
            existingExercise.CaloriesBurnedPerMinute = exerciseDto.CaloriesBurnedPerMinute;
            existingExercise.Duration = exerciseDto.Duration;
            existingExercise.WorkoutID = exerciseDto.WorkoutID;

            await _context.SaveChangesAsync();
            return existingExercise;
        }
    }
}