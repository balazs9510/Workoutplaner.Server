using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly WorkoutContext _context;
        public ExerciseService(WorkoutContext context)
        {
            _context = context;
        }
        public IEnumerable<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }
    }
}
