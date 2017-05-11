using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public interface IMonthlyWorkoutService
    {
        MonthlyWorkout GetMonthlyWorkout(int id);
        IEnumerable<MonthlyWorkout> GetMonthlyWorkouts();
        MonthlyWorkout InsertMonthlyWorkout(MonthlyWorkout newMonthlyWorkout);
        void UpdateMonthlyWorkout(int id, MonthlyWorkout updatedMonthlyWorkout);
        void DeleteMonthlyWorkout(int id);
    }
}
