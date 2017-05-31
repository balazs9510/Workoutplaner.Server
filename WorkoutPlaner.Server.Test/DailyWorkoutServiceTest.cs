using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Exceptions;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;
using Workoutplaner.Server.Services;

namespace WorkoutPlaner.Server.Test
{
    [TestClass]
    public class DailyWorkoutServiceTest
    {
        private static IDailyWorkoutService _dailyWorkoutService;
        private static ApplicationUser _testUser;

        [ClassInitialize]
        public static void Init(TestContext c)
        {
            var options = new DbContextOptionsBuilder<WorkoutContext>()
                .UseInMemoryDatabase()
                .Options;
            var optionsExercise = new DbContextOptionsBuilder<ExerciseContext>()
                .UseInMemoryDatabase()
                .Options;
            var context = new ExerciseContext(optionsExercise);
            var _context = new WorkoutContext(options, true);
            _dailyWorkoutService = new DailyWorkoutService(_context,
                   context);
            if (_context.Users.Count() != 0)
            {
                foreach (ApplicationUser u in _context.Users)
                    _context.Users.Remove(u);
            }
            if (_context.DailyWorkouts.Count() != 0)
            {
                foreach (DailyWorkout u in _context.DailyWorkouts)
                    _context.DailyWorkouts.Remove(u);
            }
            if (_context.WeeklyWorkouts.Count() != 0)
            {
                foreach (WeeklyWorkout u in _context.WeeklyWorkouts)
                    _context.WeeklyWorkouts.Remove(u);
            }
            if (_context.MonthlyWorkouts.Count() != 0)
            {
                foreach (MonthlyWorkout u in _context.MonthlyWorkouts)
                    _context.MonthlyWorkouts.Remove(u);
            }
            _testUser = new ApplicationUser()
            {
                Email = "testUser98@test.com",
                DailyWorkouts = new List<DailyWorkout>()
            };
            _context.Users.Add(_testUser);
        }
                                                            
        [TestMethod]
        [ExpectedException(typeof(NotValidStateException))]
        public void TryToInsertNotValidDailyWorkout()
        {
            //Arrange

            //Act
            _dailyWorkoutService.InsertDailyWorkout(new Workoutplaner.Server.Models.DailyWorkout()
            { Name = "Teszt" },
               _testUser);
            //Assert

        }
        
        [TestMethod]
        public void InsertValidDailyWorkout()
        {
            //Arrange
            var listExercises = new List<ExerciseItem>();
            listExercises.Add(new ExerciseItem()
            {
                Name = "teszt",
                Description = "",
                MuscleGroup = "",
                Reps = 1,
                SerialNumber = 1
            });

            //Act

            _dailyWorkoutService.InsertDailyWorkout(new DailyWorkout()
            { Name = "Teszt78", Exercises = listExercises },
                _testUser);
            //Assert
            Assert.AreEqual(1, _dailyWorkoutService.GetDailyWorkouts(_testUser).Count());

        }
       
        [TestMethod]
        public void UpdateDailyWorkout()
        {
            //Arrangevar listExercises = new List<ExerciseItem>();
            var listExercises = new List<ExerciseItem>();
            listExercises.Add(new ExerciseItem()
            {
                Name = "teszt78",
                Description = "",
                MuscleGroup = "",
                Reps = 1,
                SerialNumber = 1
            });
            var saveInstance = new DailyWorkout() { Name = "Test788", Exercises = listExercises };

            //Act
            saveInstance.Id = _dailyWorkoutService.InsertDailyWorkout(saveInstance, _testUser).Id;
            saveInstance.Name = "TestUpdate";
            _dailyWorkoutService.UpdateDailyWorkout(saveInstance.Id, saveInstance);

            //Assert
            Assert.AreEqual(_dailyWorkoutService
                .GetDailyWorkout(saveInstance.Id, _testUser).Name, "TestUpdate");

        }

        [TestMethod]
        public void DeleteDailyWorkout()
        {
            //Arrange
            var listExercises = new List<ExerciseItem>();
            listExercises.Add(new ExerciseItem()
            {
                Name = "teszt",
                Description = "",
                MuscleGroup = "",
                Reps = 1,
                SerialNumber = 1
            });
            var saveInstance = new DailyWorkout()
            { Name = "Teszt272", Exercises = listExercises };

            //Act

            var id = _dailyWorkoutService.InsertDailyWorkout(saveInstance,
                _testUser).Id;
            _dailyWorkoutService.DeleteDailyWorkout(id, _testUser);

            //Assert
            Assert.IsTrue(_dailyWorkoutService
                .GetDailyWorkouts(_testUser).Count() == 2);
        }
    }
}
