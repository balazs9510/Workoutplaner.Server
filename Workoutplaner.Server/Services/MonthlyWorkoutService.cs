using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public class MonthlyWorkoutService : IMonthlyWorkoutService
    {
        private readonly WorkoutContext _context;
        public MonthlyWorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        public MonthlyWorkout GetMonthlyWorkout(int id, ApplicationUser user)
        {
            return _context.MonthlyWorkouts
                .Include(m => m.WeekOne)
                .Include(m => m.WeekTwo)
                .Include(m => m.WeekThree)
                .Include(m => m.WeekFour)
                .SingleOrDefault(dw => dw.Id == id) ?? throw new EntityNotFoundException("Nem található az edzés");
        }

        public IEnumerable<MonthlyWorkout> GetMonthlyWorkouts(ApplicationUser user)
        {
            return _context.MonthlyWorkouts
                .Include(m => m.WeekOne)
                .Include(m => m.WeekTwo)
                .Include(m => m.WeekThree)
                .Include(m => m.WeekFour)
                .Where(m=> m.UserID.Equals(user.Id))
                .ToList();
        }

        public MonthlyWorkout InsertMonthlyWorkout(MonthlyWorkout newMonthlyWorkout,
            ApplicationUser user)
        {
            var saveInstance = new MonthlyWorkout()
            {
                Name = newMonthlyWorkout.Name
            };
            saveInstance.WeekOne = _context.WeeklyWorkouts
                .Where(w => w.Id == newMonthlyWorkout.WeekOne.Id).SingleOrDefault();
            saveInstance.WeekTwo = _context.WeeklyWorkouts
                .Where(w => w.Id == newMonthlyWorkout.WeekTwo.Id).SingleOrDefault();
            saveInstance.WeekThree = _context.WeeklyWorkouts
                .Where(w => w.Id == newMonthlyWorkout.WeekThree.Id).SingleOrDefault();
            saveInstance.WeekFour = _context.WeeklyWorkouts
                .Where(w => w.Id == newMonthlyWorkout.WeekFour.Id).SingleOrDefault();
            saveInstance.UserID = user.Id;
            user.MonthlyWorkouts.Add(saveInstance);
            _context.MonthlyWorkouts.Add(saveInstance);

            _context.SaveChanges();

            return newMonthlyWorkout;
        }

        public void UpdateMonthlyWorkout(int id, MonthlyWorkout updatedMonthlyWorkout)
        {
            updatedMonthlyWorkout.Id = id;

            _context.Entry(updatedMonthlyWorkout).State = EntityState.Modified;
            updatedMonthlyWorkout.WeekOne = _context.WeeklyWorkouts
                 .Where(w => w.Id == updatedMonthlyWorkout.WeekOne.Id).SingleOrDefault();
            updatedMonthlyWorkout.WeekTwo = _context.WeeklyWorkouts
                .Where(w => w.Id == updatedMonthlyWorkout.WeekTwo.Id).SingleOrDefault();
            updatedMonthlyWorkout.WeekThree = _context.WeeklyWorkouts
                .Where(w => w.Id == updatedMonthlyWorkout.WeekThree.Id).SingleOrDefault();
            updatedMonthlyWorkout.WeekFour = _context.WeeklyWorkouts
                .Where(w => w.Id == updatedMonthlyWorkout.WeekFour.Id).SingleOrDefault();
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Létezett-e egyáltalán
                var _ = _context.MonthlyWorkouts.AsNoTracking().SingleOrDefault(p => p.Id == id)
                    ?? throw new EntityNotFoundException("Nem található az edzés");

                throw;
            }
        }
        public void DeleteMonthlyWorkout(int id, ApplicationUser user)
        {
            var toDelete = _context.MonthlyWorkouts.SingleOrDefault(p => p.Id == id);
            user.MonthlyWorkouts.Remove(toDelete);
             _context.MonthlyWorkouts.Remove(toDelete);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _ = _context.MonthlyWorkouts.AsNoTracking().SingleOrDefault(p => p.Id == id)
                    ?? throw new EntityNotFoundException("Nem található az edzés");

                throw;
            }
        }
    }
}
