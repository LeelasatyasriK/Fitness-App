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
    public class ProgressRepository : IProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgressRepository(ApplicationDbContext context)
        {
           _context = context;   
        }
        public async Task<Models.Progress> CreateProgressAsync(Models.Progress progress)
        {
            await _context.progress.AddAsync(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task<Models.Progress?> DeleteProgressAsync(int id)
        {
           var progress = await _context.progress.FirstOrDefaultAsync(p => p.ProgressID == id);

            if(progress == null)
            {
                return null;
            }
            _context.progress.Remove(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task<List<Models.Progress>> GetAllProgressesAsync()
        {
           return await _context.progress.ToListAsync();
        }

        public async Task<Models.Progress?> GetProgressByIdAsync(int id)
        {
            return await _context.progress.FindAsync(id);
        }

        public async Task<Models.Progress?> UpdateProgressAsync(int id, UpdateProgressDto progressDto)
        {
            var existingProgress = await _context.progress.FirstOrDefaultAsync( w =>w.ProgressID ==id);
            if(existingProgress == null)
            {
                return null;
            }
            existingProgress.Date = progressDto.Date;
            existingProgress.GoalID = progressDto.GoalID;
            existingProgress.ProgressValue = progressDto.ProgressValue;

            await _context.SaveChangesAsync();
            return existingProgress;

        }
    }
}