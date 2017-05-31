using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workoutplaner.Server.Services;
using Workoutplaner.Server.Context;
using Moq;
using Workoutplaner.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WorkoutPlaner.Server.Test
{
    [TestClass]
    public class ExerciseServiceTest
    {
        private  IExerciseService _exerciseService;
   
        [TestMethod]
        public void AddExercise()
        {
            var options = new DbContextOptionsBuilder<ExerciseContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using(var context = new ExerciseContext(options))
            {
                _exerciseService = new ExerciseService(context);
                Assert.AreEqual(1, _exerciseService.InsertExercise(new Exercise() { Name = "test" }));
            }

        }
        
        [TestMethod]
        public void GetCurrentNum()
        {
            var options = new DbContextOptionsBuilder<ExerciseContext>()
                            .UseInMemoryDatabase(databaseName: "Get_current_num")
                            .Options;
            using (var context = new ExerciseContext(options))
            {
                _exerciseService = new ExerciseService(context);
                for (int i = 0; i < 20; i++)
                {
                    _exerciseService.InsertExercise(new Exercise() { Name = "test" });
                }

            }
            using (var context = new ExerciseContext(options))
            {
                Assert.AreEqual(20, context.Exercises.Count());
            }
        }
    }
}
