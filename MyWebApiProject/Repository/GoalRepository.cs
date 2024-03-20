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
    public class GoalRepository : IGoalRepository
    {

        private readonly ApplicationDbContext _context;

        public GoalRepository(ApplicationDbContext context)
        {
           _context = context;   
        }
        public async Task<Models.Goals> CreateGoalAsync(Models.Goals goals)
        {
            await _context.goals.AddAsync(goals);
            await _context.SaveChangesAsync();
            return goals;
        }

        public async Task<Models.Goals?> DeleteGoalAsync(int id)
        {
             var goal = await _context.goals.FirstOrDefaultAsync(g => g.GoalID == id);

            if(goal == null)
            {
                return null;
            }
            _context.goals.Remove(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        // public async Task<List<Models.Goals>> GetAllGoalsAsync()
        // {
        //     return await _context.goals.Include(e =>e.exercises).ToListAsync();
        // }

        // public async Task<Models.Goals?> GetGoalByIdAsync(int id)
        // {
        //     return await _context.goals.Include(e =>e.exercises).FirstOrDefaultAsync(i =>i.GoalID == id);
        // }

        public async Task<List<Models.Goals>> GetAllGoalsAsync()
        {
         return await _context.goals
        .Include(g => g.exercises)
        .Include(g => g.progress) // Include progress
        .ToListAsync();
        }

       public async Task<Models.Goals?> GetGoalByIdAsync(int id)
      {
           return await _context.goals
        .Include(g => g.exercises)
        .Include(g => g.progress) // Include progress
        .FirstOrDefaultAsync(i => i.GoalID == id);
         }


        public async Task<Models.Goals?> UpdateGoalAsync(int id, UpdateGoalDto goalsDto)
        {
           var existingGoal = await _context.goals.FirstOrDefaultAsync( w =>w.GoalID ==id);
            if(existingGoal == null)
            {
                return null;
            }
            existingGoal.GoalType = goalsDto.GoalType;
            existingGoal.TargetDate = goalsDto.TargetDate;

            await _context.SaveChangesAsync();
            return existingGoal;
        }
    }
}