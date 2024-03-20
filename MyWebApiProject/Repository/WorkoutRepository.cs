using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Data;
using MyWebApiProject.Interfaces;
using MyWebApiProject.Models;

namespace MyWebApiProject.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRepository(ApplicationDbContext context)
        {
           _context = context;   
        }

        public async Task<Workouts> CreateWorkoutAsync(Workouts workouts)
        {
            await _context.workouts.AddAsync(workouts);
            await _context.SaveChangesAsync();
            return workouts;
        }

        public async Task<Workouts?> DeleteWorkoutAsync(int id)
        {
            var workkouts = await _context.workouts.Include(w => w.exercise).FirstOrDefaultAsync(w => w.WorkoutID == id);
            
            if(workkouts == null)
            {
                return null;
            }

         var exercises = workkouts.exercise.ToList(); // Make a copy of the collection

           foreach (var exercise in exercises)
           {
             exercise.WorkoutID = null;
             _context.Entry(exercise).State = EntityState.Modified;
          }

            _context.workouts.Remove(workkouts);
            await _context.SaveChangesAsync();
            return workkouts;
        }

        public async Task<List<Workouts>> GetAllWorkoutsAsync()
        {
            return await _context.workouts.Include(e => e.exercise).ToListAsync();
        }

        public async Task<Workouts?> GetWorkoutByIdAsync(int id)
        {
           return await _context.workouts.Include(e => e.exercise).FirstOrDefaultAsync(i => i.WorkoutID == id);
        }

        public async Task<Workouts?> UpdateWorkoutAsync(int id, DTOs.UpdateWotkoutDto wotkoutDto)
        {
            var existingWorkout = await _context.workouts.FirstOrDefaultAsync( w =>w.WorkoutID ==id);
            if(existingWorkout == null)
            {
                return null;
            }

            existingWorkout.Date = wotkoutDto.Date;
            existingWorkout.CaloriesBurned = wotkoutDto.CaloriesBurned;

            await _context.SaveChangesAsync();
            return existingWorkout;

        }
    }
}