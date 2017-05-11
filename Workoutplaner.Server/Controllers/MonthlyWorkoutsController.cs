using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workoutplaner.Server.Services;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/MonthlyWorkouts")]
    public class MonthlyWorkoutsController : Controller
    {
        private readonly IMonthlyWorkoutService _monthlyWorkoutService;

        public MonthlyWorkoutsController(IMonthlyWorkoutService monthlyWorkoutService)
        {
            _monthlyWorkoutService = monthlyWorkoutService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_monthlyWorkoutService.GetMonthlyWorkouts());
        }
        [HttpGet("{id}")]
        public IActionResult GetDailyWorkout(int id)
        {
            return Ok(_monthlyWorkoutService.GetMonthlyWorkout(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]MonthlyWorkout monthlyWorkout)
        {
            var created = _monthlyWorkoutService.InsertMonthlyWorkout(monthlyWorkout);
            return CreatedAtAction(nameof(Get), new { created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MonthlyWorkout monthlyWorkout)
        {
            _monthlyWorkoutService.UpdateMonthlyWorkout(id, monthlyWorkout);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _monthlyWorkoutService.DeleteMonthlyWorkout(id);

            return NoContent();
        }
    }
}