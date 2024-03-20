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
    [ApiController]
    [Route("/goals")]
    public class GoalsController:ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public readonly IGoalRepository _goalRepo;
        public GoalsController(ApplicationDbContext context, IGoalRepository goalRepo)
        {
            _context = context;
            _goalRepo = goalRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals(){
            var goals = await _goalRepo.GetAllGoalsAsync();
            var goal = goals.Select(g => g.ToGoalsDto());
            return Ok(goals);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGoalById([FromRoute] int id)
        {
            var goal = await _goalRepo.GetGoalByIdAsync(id);
            if(goal == null){
                return NotFound();
            }
            return Ok(goal.ToGoalsDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] CreateGoalDto createGoalDto)
        {
            var goal = createGoalDto.ToCreateGoalsDto();
            await _goalRepo.CreateGoalAsync(goal);
            
            //return CreatedAtAction(nameof(GetGoalById), new{id = goal.GoalID}, goal.ToGoalsDto());
              return Ok(goal);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateGoal([FromRoute] int id, [FromBody] UpdateGoalDto updateGoal)
        {
            var goal = await _goalRepo.UpdateGoalAsync(id,updateGoal);
            if(goal == null)
            {
                return NotFound();
            }
          
            return Ok(goal.ToGoalsDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteGoal([FromRoute] int id)
        {
            var goal = await _goalRepo.DeleteGoalAsync(id);

            if(goal == null)
            {
                return NotFound();
            }


            return NoContent();
        }
    }
}