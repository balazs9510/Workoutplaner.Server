using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<DailyWorkout> DailyWorkouts { get; set; }
        public ICollection<DoneDailyWorkout> DonedDailyWorkouts { get; set; }
        public ICollection<WeeklyWorkout> WeeklyWorkouts { get; set; }
        public ICollection<MonthlyWorkout> MonthlyWorkouts { get; set; }
    }
}
