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
using System.Security.Claims;
using Workoutplaner.Server.Context;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/DailyWorkouts")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class DailyWorkoutsController : BaseController
    {
        private readonly IDailyWorkoutService _dailyWorkoutService;
        
        public DailyWorkoutsController(IDailyWorkoutService dailyWorkotuService,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor accessor,
            WorkoutContext cotnext)
            :base(userManager,accessor,cotnext)
        {
            _dailyWorkoutService = dailyWorkotuService;
                       
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_dailyWorkoutService.GetDailyWorkouts(_user));
        }

        [HttpGet("{id}")]
        public IActionResult GetDailyWorkout(int id)
        {
            return Ok(_dailyWorkoutService.GetDailyWorkout(id,_user));
        }
        [HttpPost]
        public IActionResult Post([FromBody]DailyWorkout dailyWorkout)
        {
            var created = _dailyWorkoutService.InsertDailyWorkout(dailyWorkout,_user);
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
                _dailyWorkoutService.DeleteDailyWorkout(id,_user);
            }
            catch (EntityCannotDeleteException)
            {
                return BadRequest();
            }
            
            return NoContent();
        }
    }
}