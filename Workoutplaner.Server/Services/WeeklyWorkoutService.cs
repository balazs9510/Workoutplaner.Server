using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Exceptions;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public class WeeklyWorkoutService : IWeeklyWorkoutService
    {
        private readonly WorkoutContext _context;
        public WeeklyWorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        public WeeklyWorkout GetWeeklyWorkout(int id, ApplicationUser user)
        {
            
            return _context.WeeklyWorkouts
                .Include(d => d.DayOne)
                .Include(d => d.DayOne)
                .Include(d => d.DayTwo)
                .Include(d => d.DayThree)
                .Include(d => d.DayFour)
                .Include(d => d.DayFive)
                .Include(d => d.DaySix)
                .Include(d => d.DaySeven)
                .SingleOrDefault(dw => dw.Id == id) ?? throw new EntityNotFoundException("Nem található az edzés");
        }

        public IEnumerable<WeeklyWorkout> GetWeeklyWorkouts(ApplicationUser user)
        {
            return _context.WeeklyWorkouts
                .Include(d => d.DayOne)
                .Include(d => d.DayOne)
                .Include(d => d.DayTwo)
                .Include(d => d.DayThree)
                .Include(d => d.DayFour)
                .Include(d => d.DayFive)
                .Include(d => d.DaySix)
                .Include(d => d.DaySeven)
                .Where(d=>d.UserID.Equals(user.Id))
                .ToList();
        }

        public WeeklyWorkout InsertWeeklyWorkout(WeeklyWorkout newWeeklyWorkout, ApplicationUser user)
        {
            var toSave = new WeeklyWorkout()
            {
                Name = newWeeklyWorkout.Name,

                WorkoutType = Models.Type.Weekly
            };
            toSave.UserID = user.Id;
            user.WeeklyWorkouts.Add(toSave);
            _context.WeeklyWorkouts.Add(toSave);
            toSave.DayOne = _context.DailyWorkouts
                .Where(m => m.Id == newWeeklyWorkout.DayOne.Id).SingleOrDefault();
            toSave.DayTwo = _context.DailyWorkouts
                .Where(m => m.Id ==newWeeklyWorkout.DayTwo.Id).SingleOrDefault();
            toSave.DayThree = _context.DailyWorkouts
                .Where(m => m.Id ==newWeeklyWorkout.DayThree.Id).SingleOrDefault();
            toSave.DayFour = _context.DailyWorkouts
                .Where(m => m.Id ==newWeeklyWorkout.DayFour.Id).SingleOrDefault();
            toSave.DayFive = _context.DailyWorkouts
                .Where(m => m.Id ==newWeeklyWorkout.DayFive.Id).SingleOrDefault();
            toSave.DaySix = _context.DailyWorkouts
                .Where(m => m.Id ==newWeeklyWorkout.DaySix.Id).SingleOrDefault();
            toSave.DaySeven = _context.DailyWorkouts
                .Where(m => m.Id ==newWeeklyWorkout.DaySeven.Id).SingleOrDefault();

            _context.SaveChanges();

            return toSave;
        }

        public void UpdateWeeklyWorkout(int id,
            WeeklyWorkout updatedWeeklyWorkout)
        {
            
            _context.Entry(updatedWeeklyWorkout).State = EntityState.Modified;
            var saveInstace = _context.WeeklyWorkouts.SingleOrDefault(m => m.Id == updatedWeeklyWorkout.Id);
            saveInstace.Name = updatedWeeklyWorkout.Name;
            saveInstace
                .DayOne = _context.DailyWorkouts.SingleOrDefault(p=>p.Id == updatedWeeklyWorkout.DayOne.Id);
            saveInstace.DayTwo =   _context.DailyWorkouts.SingleOrDefault(p=>p.Id == updatedWeeklyWorkout.DayTwo.Id);
            saveInstace.DayThree = _context.DailyWorkouts.SingleOrDefault(p=>p.Id == updatedWeeklyWorkout.DayThree.Id);
            saveInstace.DayFour =  _context.DailyWorkouts.SingleOrDefault(p=>p.Id == updatedWeeklyWorkout.DayFour.Id);
            saveInstace.DayFive =  _context.DailyWorkouts.SingleOrDefault(p=>p.Id == updatedWeeklyWorkout.DayFive.Id);
            saveInstace.DaySix =   _context.DailyWorkouts.SingleOrDefault(p=>p.Id == updatedWeeklyWorkout.DaySix.Id);
            saveInstace.DaySeven = _context.DailyWorkouts.SingleOrDefault(p => p.Id == updatedWeeklyWorkout.DaySeven.Id);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Létezett-e egyáltalán
                var _ = _context.WeeklyWorkouts.AsNoTracking().SingleOrDefault(p => p.Id == id)
                    ?? throw new EntityNotFoundException("Nem található az edzés");

                throw;
            }
        }
        public void DeleteWeeklyWorkout(int id,ApplicationUser user)
        {
            var weeklyWorkout = _context.WeeklyWorkouts
                .SingleOrDefault(m => m.Id == id);
            var montlyWorkout = _context.MonthlyWorkouts.Where(w =>
               (w.WeekOne.Id == weeklyWorkout.Id ||
               w.WeekTwo.Id == weeklyWorkout.Id ||
               w.WeekThree.Id == weeklyWorkout.Id ||
               w.WeekFour.Id == weeklyWorkout.Id)).FirstOrDefault();
            if (montlyWorkout == null)
            {
                var toDelete = _context.WeeklyWorkouts.SingleOrDefault(w => w.Id == id);
                user.WeeklyWorkouts.Remove(toDelete);
                _context.WeeklyWorkouts.Remove(toDelete);

            }
            else
                throw new EntityCannotDeleteException();

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _ = _context.WeeklyWorkouts.AsNoTracking().SingleOrDefault(p => p.Id == id)
                    ?? throw new EntityNotFoundException("Nem található az edzés");

                throw;
            }
           
           
        }
    }
}
