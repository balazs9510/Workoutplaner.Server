using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workoutplaner.Server.Services;
using Workoutplaner.Server.Models;
using Microsoft.AspNetCore.Identity;
using Workoutplaner.Server.Models.Identity;
using Workoutplaner.Server.Context;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/MonthlyWorkouts")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class MonthlyWorkoutsController : BaseController
    {
        private readonly IMonthlyWorkoutService _monthlyWorkoutService;

        public MonthlyWorkoutsController(IMonthlyWorkoutService monthlyWorkoutService,
            UserManager<ApplicationUser> userManager, 
            IHttpContextAccessor accessor,
            WorkoutContext context)
            :base(userManager,accessor,context)
        {
            _monthlyWorkoutService = monthlyWorkoutService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_monthlyWorkoutService.GetMonthlyWorkouts(_user));
        }
        [HttpGet("{id}")]
        public IActionResult GetDailyWorkout(int id)
        {
            return Ok(_monthlyWorkoutService.GetMonthlyWorkout(id,_user));
        }
        [HttpPost]
        public IActionResult Post([FromBody]MonthlyWorkout monthlyWorkout)
        {
            var created = _monthlyWorkoutService.InsertMonthlyWorkout(monthlyWorkout, _user);
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
            _monthlyWorkoutService.DeleteMonthlyWorkout(id, _user);
            return NoContent();
        }
    }
}