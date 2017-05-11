using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public interface IDailyWorkoutService
    {
        DailyWorkout GetDailyWorkout(int id);
        IEnumerable<DailyWorkout> GetDailyWorkouts();
        DailyWorkout InsertDailyWorkout(DailyWorkout newDailyWorkout);
        void UpdateDailyWorkout(int id, DailyWorkout updatedDailyWorkout);
        void DeleteDailyWorkout(int id);
    }
}
