using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models
{
    public class DoneDailyWorkout
    {
       
        public string UserId { get; set; }
        public double LastInMinute { get; set; }
        public DailyWorkout DonedWorkout { get; set; }
       
        public DateTime Date { get; set; }
    }
}
