using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;
using Workoutplaner.Server.Services;

namespace WorkoutPlaner.Server.Test
{
    [TestClass]
    public class MonthlyWorkoutServiceTest
    {
        private static IMonthlyWorkoutService _monthWorkoutService;
        private static ApplicationUser _testUser;
        private static WorkoutContext _context;
        private static WeeklyWorkout _testWeeklyWorkout = new WeeklyWorkout();        
        private MonthlyWorkout _testWorkout = new MonthlyWorkout();
        [ClassInitialize]
        public static void Init(TestContext c)
        {
            var options = new DbContextOptionsBuilder
                <WorkoutContext>()
                .UseInMemoryDatabase()
                .Options;

            _context = new WorkoutContext(options, true);
            _monthWorkoutService = new MonthlyWorkoutService(_context);
            _testUser = new ApplicationUser()
            {
                Email = "testUser@test.com",
                DailyWorkouts = new List<DailyWorkout>(),
                WeeklyWorkouts = new List<WeeklyWorkout>(),
                MonthlyWorkouts = new List<MonthlyWorkout>()
            };
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
            _context.Users.Add(_testUser);
            _context.WeeklyWorkouts.Add(_testWeeklyWorkout);
            _context.SaveChanges();
        } 

        [TestMethod]
        public void InsertMotnhlyWorkout()
        {
            //Arrange
            var saveInstance = new MonthlyWorkout()
            {
                Name = "TestMonthly",
                WeekFour = _testWeeklyWorkout,
                WeekOne = _testWeeklyWorkout,
                WeekThree = _testWeeklyWorkout,
                WeekTwo = _testWeeklyWorkout
            };

            //Act
            _testWorkout = _monthWorkoutService.InsertMonthlyWorkout(saveInstance, _testUser);

            //Asser
            Assert.IsFalse(_monthWorkoutService.GetMonthlyWorkouts(_testUser).Count() != 1);
        }

        [TestMethod]
        public void UpdateMonthlyWorkout()
        {
            //Arrange
            _testWorkout = _monthWorkoutService.GetMonthlyWorkouts(_testUser).FirstOrDefault();
            //Act
            _testWorkout.Name = "Ultra kemény királyság";
            _monthWorkoutService.UpdateMonthlyWorkout(_testWorkout.Id, _testWorkout);

            //Assert
            Assert.AreEqual(_monthWorkoutService
                .GetMonthlyWorkout(_testWorkout.Id, _testUser).Name,
               "Ultra kemény királyság");
        }

        [TestMethod]
        public void DeleteMonthlyWorkout()
        {
            //Arrange
            var saveInstance = new MonthlyWorkout()
            {
                Name = "TestMonthly",
                WeekFour = _testWeeklyWorkout,
                WeekOne = _testWeeklyWorkout,
                WeekThree = _testWeeklyWorkout,
                WeekTwo = _testWeeklyWorkout
            };
            _testWorkout = _monthWorkoutService.InsertMonthlyWorkout(saveInstance, _testUser);

            //Act
            var countBefore = _monthWorkoutService.GetMonthlyWorkouts(_testUser).Count();
            _monthWorkoutService
                .DeleteMonthlyWorkout(_testWorkout.Id, _testUser);
            var countAfter = _monthWorkoutService.GetMonthlyWorkouts(_testUser).Count();

            //Assert
            Assert.AreNotEqual(countAfter,countBefore);
        }
        
    }
}
