using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Models
{
    public enum Type
    {
        Daily,
        Weekly,
        Monthly
    }
    public abstract class BaseWorkout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type WorkoutType { get; set; }

    }
}
