using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models
{
    public class DailyWorkout : BaseWorkout
    {
        public ICollection<ExerciseItem> Exercises { get; set; }
    }
}
