using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.DTOs;

namespace MyWebApiProject.Interfaces
{
    public interface IProgressRepository
    {
        Task<List<Models.Progress>> GetAllProgressesAsync();
        Task<Models.Progress?> GetProgressByIdAsync(int id);
        Task<Models.Progress> CreateProgressAsync(Models.Progress progress);
        Task<Models.Progress?> UpdateProgressAsync(int id,UpdateProgressDto progressDto);
        Task<Models.Progress?> DeleteProgressAsync(int id);
    }
}