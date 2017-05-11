using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models
{
    public class WeeklyWorkout : BaseWorkout
    {
        public DailyWorkout DayOne { get; set; }
        public DailyWorkout DayTwo { get; set; }
        public DailyWorkout DayThree { get; set; }
        public DailyWorkout DayFour { get; set; }
        public DailyWorkout DayFive { get; set; }
        public DailyWorkout DaySix { get; set; }
        public DailyWorkout DaySeven { get; set; }

    }
}
