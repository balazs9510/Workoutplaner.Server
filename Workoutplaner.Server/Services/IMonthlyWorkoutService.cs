using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public interface IMonthlyWorkoutService
    {
        MonthlyWorkout GetMonthlyWorkout(int id, ApplicationUser user);
        IEnumerable<MonthlyWorkout> GetMonthlyWorkouts(ApplicationUser user);
        MonthlyWorkout InsertMonthlyWorkout(MonthlyWorkout newMonthlyWorkout,
            ApplicationUser user);
        void UpdateMonthlyWorkout(int id, MonthlyWorkout updatedMonthlyWorkout);
        void DeleteMonthlyWorkout(int id, ApplicationUser user);
    }
}
