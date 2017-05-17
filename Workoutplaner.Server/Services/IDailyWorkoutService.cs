using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public interface IDailyWorkoutService
    {
        DailyWorkout GetDailyWorkout(int id, ApplicationUser user);
        IEnumerable<DailyWorkout> GetDailyWorkouts( ApplicationUser user);
        DailyWorkout InsertDailyWorkout(DailyWorkout newDailyWorkout, ApplicationUser user);
        void UpdateDailyWorkout(int id, DailyWorkout updatedDailyWorkout);
        void DeleteDailyWorkout(int id, ApplicationUser user);
    }
}
