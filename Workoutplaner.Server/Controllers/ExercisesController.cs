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

    }
}