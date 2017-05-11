using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public interface IWeeklyWorkoutService
    {
        WeeklyWorkout GetWeeklyWorkout(int id);
        IEnumerable<WeeklyWorkout> GetWeeklyWorkouts();
        WeeklyWorkout InsertWeeklyWorkout(WeeklyWorkout newWeeklyWorkout);
        void UpdateWeeklyWorkout(int id, WeeklyWorkout updatedWeeklyWorkout);
        void DeleteWeeklyWorkout(int id);
    }
}
