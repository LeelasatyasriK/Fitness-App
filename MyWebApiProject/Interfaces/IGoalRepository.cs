using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;

namespace MyWebApiProject.Interfaces
{
    public interface IGoalRepository
    {
        Task<List<Models.Goals>> GetAllGoalsAsync();
        Task<Models.Goals?> GetGoalByIdAsync(int id);
        Task<Models.Goals> CreateGoalAsync(Models.Goals goals);
        Task<Models.Goals?> UpdateGoalAsync(int id,UpdateGoalDto goalsDto);
        Task<Models.Goals?> DeleteGoalAsync(int id);
    }
}