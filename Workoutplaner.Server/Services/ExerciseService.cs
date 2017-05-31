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
        private readonly ExerciseContext _context;
        public ExerciseService(ExerciseContext context)
        {
            _context = context;
        }
        public IEnumerable<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }
        public IEnumerable<Exercise> GetExercisesByMuscleGroup(string muscleGroup)
        {
            return _context.Exercises.Where(e => e.MuscleGroup.Equals(muscleGroup));
        }
        public int InsertExercise(Exercise exercise)
        {
            var saveItem = new Exercise()
            {
                Name = exercise.Name,
                Description = exercise.Description,
                MuscleGroup = exercise.MuscleGroup
            };
            _context.Exercises.Add(saveItem);
            return _context.SaveChanges();
        }
    }
}
