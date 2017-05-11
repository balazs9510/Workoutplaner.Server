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

                var random = new Random();
                for(int i = 0; i<10; i++)
                {
                    var exercises = new List<ExerciseItem>();
                    for (int j = 0; j < random.Next()%6; j++)
                    {
                        var exercisess = context.Exercises.ToList();
                        var exercise = exercisess[random.Next() % exercisess.Count]; 
                        exercises.Add(new ExerciseItem()
                        {
                            Name = exercise.Name,
                            Description = exercise.Description,
                            SerialNumber = random.Next() % 7 +1 ,
                            Reps = random.Next() % 20+ 1,
                        });
                    }
                    var dailyWorkout = new DailyWorkout()
                    {
                        Name = "Tesztnap " + i,
                        Exercises = exercises,
                        WorkoutType = Models.Type.Daily
                    };
                    context.DailyWorkouts.Add(dailyWorkout);
                }
                context.SaveChanges();
                for (int i = 0; i < 8; i++)
                {
                    var dailyWorkouts = context.DailyWorkouts.ToList();
                    var weeklyWorkout = new WeeklyWorkout()
                    {
                        Name = "Teszthét " + i,
                        DayOne = dailyWorkouts[random.Next()%dailyWorkouts.Count],
                        DayTwo = dailyWorkouts[random.Next() % dailyWorkouts.Count],
                        DayThree = dailyWorkouts[random.Next() % dailyWorkouts.Count],
                        DayFour = dailyWorkouts[random.Next() % dailyWorkouts.Count],
                        DayFive = dailyWorkouts[random.Next() % dailyWorkouts.Count],
                        DaySix = dailyWorkouts[random.Next() % dailyWorkouts.Count],
                        DaySeven = dailyWorkouts[random.Next() % dailyWorkouts.Count],
                        WorkoutType = Models.Type.Weekly
                    };
                    context.WeeklyWorkouts.Add(weeklyWorkout);
                }
                context.SaveChanges();
                for (int i = 0; i < 4; i++)
                {
                    var weeklyWorkouts = context.WeeklyWorkouts.ToList();
                    var monthlyWorkout = new MonthlyWorkout()
                    {
                        Name = "Teszthónap " + i,
                        WeekOne = weeklyWorkouts[random.Next() % weeklyWorkouts.Count],
                        WeekTwo = weeklyWorkouts[random.Next() % weeklyWorkouts.Count],
                        WeekThree = weeklyWorkouts[random.Next() % weeklyWorkouts.Count],
                        WeekFour = weeklyWorkouts[random.Next() % weeklyWorkouts.Count],
                        WorkoutType = Models.Type.Monthly
                    };
                    context.MonthlyWorkouts.Add(monthlyWorkout);
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
