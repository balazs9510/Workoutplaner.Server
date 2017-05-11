using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models
{
    public class ExerciseItem : Exercise
    {
        public int SerialNumber { get; set; }
        public int Reps { get; set; }
    }
}
