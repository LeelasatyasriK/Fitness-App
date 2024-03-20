using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Data;
using MyWebApiProject.DTOs;
using MyWebApiProject.Interfaces;
using MyWebApiProject.Mappers;
using MyWebApiProject.Repository;

namespace MyWebApiProject.Controllers
{
    [ApiController]
    [Route("/exercise")]
    [Authorize]
    public class ExerciseController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IExerciseRepository _exerciseRepo;
        public ExerciseController(ApplicationDbContext context, IExerciseRepository exerciseRepo)
        {
            _context = context;
            _exerciseRepo = exerciseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises(){
            var exercises = await _exerciseRepo.GetAllExercisesAsync();
            var exercise = exercises.Select(e =>e.ToExcersiseDTO());
            return Ok(exercises);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExerciseById([FromRoute] int id){
            var exercise = await _exerciseRepo.GetExerciseByIdAsync(id);
            if(exercise==null){
                return NotFound();

            }
            return Ok(exercise.ToExcersiseDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDto exerciseDto)
        {
            var exercise = exerciseDto.ToCreateExerciseDto();
            await _exerciseRepo.CreateExerciseAsync(exercise);
            
            return CreatedAtAction(nameof(GetExerciseById), new{id = exercise.ExerciseID}, exercise.ToExcersiseDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] int id,[FromBody] UpdateExerciseDto updateExercise)
        {
            var exercise = await _exerciseRepo.UpdateExerciseAsync(id,updateExercise);
            if(exercise == null)
            {
                return NotFound();

            }
    
            return Ok(exercise.ToExcersiseDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            var exercise = await _exerciseRepo.DeleteExerciseAsync(id);
           

             if(exercise == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}