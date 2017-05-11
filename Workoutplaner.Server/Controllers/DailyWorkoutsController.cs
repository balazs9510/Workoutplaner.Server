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
    [Route("api/DailyWorkouts")]
    public class DailyWorkoutsController : Controller
    {
        private readonly IDailyWorkoutService _dailyWorkoutService;
        public DailyWorkoutsController(IDailyWorkoutService dailyWorkotuService)
        {
            _dailyWorkoutService = dailyWorkotuService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dailyWorkoutService.GetDailyWorkouts());
        }

        [HttpGet("{id}")]
        public IActionResult GetDailyWorkout(int id)
        {
            return Ok(_dailyWorkoutService.GetDailyWorkout(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]DailyWorkout dailyWorkout)
        {
            var created = _dailyWorkoutService.InsertDailyWorkout(dailyWorkout);
            return CreatedAtAction(nameof(Get), new { created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DailyWorkout dailyWorkout)
        {
            _dailyWorkoutService.UpdateDailyWorkout(id, dailyWorkout);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dailyWorkoutService.DeleteDailyWorkout(id);
            }
            catch (EntityCannotDeleteException)
            {
                return BadRequest();
            }
            
            return NoContent();
        }
    }
}