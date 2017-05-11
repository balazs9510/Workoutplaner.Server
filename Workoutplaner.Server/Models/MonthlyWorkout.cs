using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models
{
    public class MonthlyWorkout : BaseWorkout
    {
        public WeeklyWorkout WeekOne { get; set; }
        public WeeklyWorkout WeekTwo { get; set; }
        public WeeklyWorkout WeekThree { get; set; }
        public WeeklyWorkout WeekFour { get; set; }
    }
}
