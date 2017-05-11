using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Context
{
    public static class SeedDatabase
    {
        public static void Seed(this WorkoutContext context)
        {
            if (!context.Exercises.Any())
            {
                foreach (var exercise in LoadExercises())
                {
                    var item = new Exercise()
                    {
                        Name = exercise.Name,
                        Description = exercise.Description,
                        MuscleGroup = exercise.MuscleGroup
                    };
                    context.Exercises.Add(item);
                }
                context.SaveChanges();
            }
        }
        private static List<Exercise> LoadExercises()
        {
            var assembly = Assembly.GetEntryAssembly();
            var stream = assembly.GetManifestResourceStream("Workoutplaner.Server.exercises.json");
            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                List<Exercise> items = JsonConvert.DeserializeObject<List<Exercise>>(json);
                items.Sort((a, b) => a.Name.CompareTo(b.Name));
                return items;
            }

        }
    }
}
