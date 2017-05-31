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
    [Route("api/Exercises")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;
        public ExercisesController(IExerciseService es)
        {
            _exerciseService = es;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_exerciseService.GetExercises());
        }
        [HttpPost,MapToApiVersion("2.0")]
        public IActionResult Post([FromBody] Exercise e)
        {
            _exerciseService.InsertExercise(e);
            return Ok();
        }

    }
}