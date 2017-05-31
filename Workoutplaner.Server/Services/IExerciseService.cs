using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public interface IExerciseService
    {
        IEnumerable<Exercise> GetExercises();
        IEnumerable<Exercise> GetExercisesByMuscleGroup(string muscleGrup);
        int InsertExercise(Exercise exercise);
    }
}
