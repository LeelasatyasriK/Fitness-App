using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;

namespace MyWebApiProject.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Models.Exercises>> GetAllExercisesAsync();
        Task<Models.Exercises?> GetExerciseByIdAsync(int id);
        Task<Models.Exercises> CreateExerciseAsync(Models.Exercises exercise);
        Task<Models.Exercises?> UpdateExerciseAsync(int id, UpdateExerciseDto exerciseDto);
        Task<Models.Exercises?> DeleteExerciseAsync(int id);

    }
}