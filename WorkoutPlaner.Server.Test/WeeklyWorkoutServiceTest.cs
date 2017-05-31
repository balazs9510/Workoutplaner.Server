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
    public class WeeklyWorkoutServiceText
    {
        private static IWeeklyWorkoutService _weeklyWorkoutService;
        private static ApplicationUser _testUser;
        private static WorkoutContext _context;
        private static DailyWorkout _testDailyWorkout;
        private WeeklyWorkout _testWorkout = new WeeklyWorkout();
        [ClassInitialize]
        public static void Init(TestContext c)
        {
            var options = new DbContextOptionsBuilder
                <WorkoutContext>()
                .UseInMemoryDatabase()
                .Options;
          
            _context = new WorkoutContext(options, true);
            _weeklyWorkoutService = new WeeklyWorkoutService(_context);
            _testUser = new ApplicationUser()
            {
                Email = "testUser2@test.com",
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
            _testDailyWorkout = new DailyWorkout()
            { Id = 100, Name = "Teszt9", UserID = _testUser.Id };
            _context.DailyWorkouts.Add(_testDailyWorkout);

            _context.SaveChanges();
        }

        [TestMethod]
        public void InsertWeeklyWorkout()
        {
            //Arrange
            var saveInstance = new WeeklyWorkout()
            {
                Name = "TestWeeklyy",
                DayOne = _testDailyWorkout,
                DayTwo = _testDailyWorkout,
                DayThree = _testDailyWorkout,
                DayFour = _testDailyWorkout,
                DayFive = _testDailyWorkout,
                DaySix = _testDailyWorkout,
                DaySeven = _testDailyWorkout,
            };

            //Act
            var coutnBefore = _weeklyWorkoutService.GetWeeklyWorkouts(_testUser).Count();
            _weeklyWorkoutService.InsertWeeklyWorkout(saveInstance, _testUser);
            var coutnAfter = _weeklyWorkoutService.GetWeeklyWorkouts(_testUser).Count();

            //Asser
            Assert.AreNotEqual(coutnAfter,coutnBefore);
        }

        [TestMethod]
        public void UpdateWeeklyWorkout()
        {
            //Arrange
            var saveInstance = new WeeklyWorkout()
            {
                Name = "TestWeekly",
                DayOne = _testDailyWorkout,
                DayTwo = _testDailyWorkout,
                DayThree = _testDailyWorkout,
                DayFour = _testDailyWorkout,
                DayFive = _testDailyWorkout,
                DaySix = _testDailyWorkout,
                DaySeven = _testDailyWorkout,
            };
            _testWorkout = _weeklyWorkoutService.InsertWeeklyWorkout(saveInstance, _testUser);
            
            //Act
            _testWorkout.Name = "Ultra kemény királyság";
            _weeklyWorkoutService.UpdateWeeklyWorkout(_testWorkout.Id, _testWorkout);

            //Assert
            Assert.AreEqual(_weeklyWorkoutService.GetWeeklyWorkout(_testWorkout.Id, _testUser).Name,
               "Ultra kemény királyság");
        }

        [TestMethod]
        public void DeleteWeeklyWorkout()
        {
            //Arrange
            var saveInstance = new WeeklyWorkout()
            {
                Name = "TestWeekly8",
                DayOne = _testDailyWorkout,
                DayTwo = _testDailyWorkout,
                DayThree = _testDailyWorkout,
                DayFour = _testDailyWorkout,
                DayFive = _testDailyWorkout,
                DaySix = _testDailyWorkout,
                DaySeven = _testDailyWorkout,
            };
            var _testWorkout1 = _weeklyWorkoutService.InsertWeeklyWorkout(saveInstance, _testUser);

            //Act
            var countBefore = _weeklyWorkoutService.GetWeeklyWorkouts(_testUser).Count();
            _weeklyWorkoutService.DeleteWeeklyWorkout(_testWorkout1.Id,_testUser);
            var countAfter = _weeklyWorkoutService.GetWeeklyWorkouts(_testUser).Count();
            //Assert
            Assert.AreNotEqual(countBefore,countAfter);
        }
        
    }
}
