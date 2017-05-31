using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workoutplaner.Server.Services;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Exceptions;
using Microsoft.AspNetCore.Identity;
using Workoutplaner.Server.Models.Identity;
using Workoutplaner.Server.Context;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/WeeklyWorkouts")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class WeeklyWorkoutsController : BaseController
    {
        private readonly IWeeklyWorkoutService _weeklyWorkoutService;

        public WeeklyWorkoutsController(IWeeklyWorkoutService weeklyWorkoutService, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor accessor,
            WorkoutContext context)
            :base(userManager,accessor,context)
        {
            _weeklyWorkoutService = weeklyWorkoutService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_weeklyWorkoutService.GetWeeklyWorkouts(_user));
        }
        [HttpGet("{id}")]
        public IActionResult GetDailyWorkout(int id)
        {
            return Ok(_weeklyWorkoutService.GetWeeklyWorkout(id, _user));
        }
        [HttpPost]
        public IActionResult Post([FromBody]WeeklyWorkout weeklyWorkout)
        {
            var created = _weeklyWorkoutService.InsertWeeklyWorkout(weeklyWorkout, _user);
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
                _weeklyWorkoutService.DeleteWeeklyWorkout(id, _user);
            }
            catch (EntityCannotDeleteException)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}