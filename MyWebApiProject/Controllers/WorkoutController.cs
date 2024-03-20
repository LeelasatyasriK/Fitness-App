using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Data;
using MyWebApiProject.DTOs;
using MyWebApiProject.Interfaces;
using MyWebApiProject.Mappers;

namespace MyWebApiProject.Controllers
{
    [Route("/workouts")]
    [ApiController]
     public class WorkoutController:ControllerBase{
        private readonly ApplicationDbContext _context;
        private readonly IWorkoutRepository _workoutRepo;
       
        public WorkoutController(ApplicationDbContext context, IWorkoutRepository workoutRepo){
            _context = context;
            _workoutRepo = workoutRepo;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAllWorkouts(){
            var Workouts = await _workoutRepo.GetAllWorkoutsAsync();
            var workouts = Workouts.Select(w => w.ToWorkoutDTO());
            return Ok(Workouts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWorkoutById([FromRoute] int id){
            var workout = await _workoutRepo.GetWorkoutByIdAsync(id);
            if(workout==null){
                return NotFound();
            }
            return Ok(workout.ToWorkoutDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutRequestDto createWorkout)
        {
            var workoutModel = createWorkout.ToWorkoutCreateDto();
            await _workoutRepo.CreateWorkoutAsync(workoutModel);
            
            //return CreatedAtAction(nameof(GetWorkoutById), new{id = workoutModel.WorkoutID},workoutModel.ToWorkoutDTO());
             return Ok(workoutModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateWorkout([FromRoute] int id,[FromBody] UpdateWotkoutDto updateWotkout)
        {
            var workout = await _workoutRepo.UpdateWorkoutAsync(id,updateWotkout);
            if(workout == null)
            {
               return NotFound(); 
            }

            return Ok(workout.ToWorkoutDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteWorkout([FromRoute] int id)
       {
         var workout = await _workoutRepo.DeleteWorkoutAsync(id);

          if (workout == null)
          {
            return NotFound();
          }

        //    var exercises = workout.exercise.ToList(); // Make a copy of the collection

        //    foreach (var exercise in exercises)
        //    {
        //      exercise.WorkoutID = null;
        //      _context.Entry(exercise).State = EntityState.Modified;
        //   }

        //   _context.workouts.Remove(workout);
        //   await _context.SaveChangesAsync();
    
         return NoContent();
       }



        // public async Task<IActionResult> DeleteWorkout([FromRoute] int id)
        // {
        //    // var workout = await _context.workouts.FirstOrDefaultAsync(w => w.WorkoutID == id);

        //     var w = _context.workouts.Find(id);

        //     if (w != null && w.exercise != null)
        //     {
        //       foreach (var item in w.exercise.Where(e => e.WorkoutID == id).ToList())
        //        {
        //           item.WorkoutID = null;
        //            _context.Entry(item).State = EntityState.Modified;
        //             _context.SaveChanges();
        //        }
        //     }

        //     if(w == null)
        //     {
        //         return NotFound();

        //     }
        //      _context.workouts.Remove(w);
        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }
    }
}
