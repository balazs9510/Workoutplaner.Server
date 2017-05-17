using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public interface IWeeklyWorkoutService
    {
        WeeklyWorkout GetWeeklyWorkout(int id, ApplicationUser user);
        IEnumerable<WeeklyWorkout> GetWeeklyWorkouts( ApplicationUser user);
        WeeklyWorkout InsertWeeklyWorkout(WeeklyWorkout newWeeklyWorkout, ApplicationUser user);
        void UpdateWeeklyWorkout(int id, WeeklyWorkout updatedWeeklyWorkout);
        void DeleteWeeklyWorkout(int id, ApplicationUser user);
    }
}
