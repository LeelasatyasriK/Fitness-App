using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;
using MyWebApiProject.Models;

namespace MyWebApiProject.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Models.Workouts>> GetAllWorkoutsAsync();
        Task<Models.Workouts?> GetWorkoutByIdAsync(int id);
        Task<Models.Workouts> CreateWorkoutAsync(Models.Workouts workouts);
        Task<Models.Workouts?> UpdateWorkoutAsync(int id,UpdateWotkoutDto wotkoutDto);
        Task<Models.Workouts?> DeleteWorkoutAsync(int id);
    }
}