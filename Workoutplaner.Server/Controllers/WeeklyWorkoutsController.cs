using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workoutplaner.Server.Services;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Exceptions;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/WeeklyWorkouts")]
    public class WeeklyWorkoutsController : Controller
    {
        private readonly IWeeklyWorkoutService _weeklyWorkoutService;

        public WeeklyWorkoutsController(IWeeklyWorkoutService weeklyWorkoutService)
        {
            _weeklyWorkoutService = weeklyWorkoutService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_weeklyWorkoutService.GetWeeklyWorkouts());
        }
        [HttpGet("{id}")]
        public IActionResult GetDailyWorkout(int id)
        {
            return Ok(_weeklyWorkoutService.GetWeeklyWorkout(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]WeeklyWorkout weeklyWorkout)
        {
            var created = _weeklyWorkoutService.InsertWeeklyWorkout(weeklyWorkout);
            return CreatedAtAction(nameof(Get), new { created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeeklyWorkout weeklyWorkout)
        {
            _weeklyWorkoutService.UpdateWeeklyWorkout(id, weeklyWorkout);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _weeklyWorkoutService.DeleteWeeklyWorkout(id);
            }
            catch (EntityCannotDeleteException)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}