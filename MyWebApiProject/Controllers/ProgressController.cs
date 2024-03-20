using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyWebApiProject.Data;
using MyWebApiProject.DTOs;
using MyWebApiProject.Interfaces;
using MyWebApiProject.Mappers;

namespace MyWebApiProject.Controllers
{
    [ApiController]
    [Route("/progress")]
    public class ProgressController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProgressRepository _progressRepo;
        public ProgressController(ApplicationDbContext context, IProgressRepository progressRepo)
        {
            _context = context;
            _progressRepo = progressRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProgresses(){
            var progress = await _progressRepo.GetAllProgressesAsync();
            var progres = progress.Select(p => p.ToProgressDto());
            return Ok(progress);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProgressById([FromRoute] int id){
            var progress = await _progressRepo.GetProgressByIdAsync(id);
            if(progress == null){
                return NotFound();
            }
            return Ok(progress.ToProgressDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgress([FromBody] CreateProgressDto createProgress)
        {
            var progress = createProgress.ToCreatePrgress();
            await _progressRepo.CreateProgressAsync(progress);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProgressById),new {id = progress.ProgressID},progress.ToProgressDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProgress([FromRoute] int id, [FromBody] UpdateProgressDto updateProgress)
        {
            var progress = await _progressRepo.UpdateProgressAsync(id,updateProgress);
            if(progress == null)
            {
                return NotFound();
            }

            return Ok(progress.ToProgressDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProgress([FromRoute] int id)
        {
            var progres = await _progressRepo.DeleteProgressAsync(id);

            if(progres == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}