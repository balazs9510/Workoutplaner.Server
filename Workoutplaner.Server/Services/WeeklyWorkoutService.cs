using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public class WeeklyWorkoutService : IWeeklyWorkoutService
    {
        private readonly WorkoutContext _context;
        public WeeklyWorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        public WeeklyWorkout GetWeeklyWorkout(int id)
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

        public IEnumerable<WeeklyWorkout> GetWeeklyWorkouts()
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
                .ToList();
        }

        public WeeklyWorkout InsertWeeklyWorkout(WeeklyWorkout newWeeklyWorkout)
        {
            newWeeklyWorkout.Id = _context.WeeklyWorkouts.Max(p => p.Id) + 1;

            _context.WeeklyWorkouts.Add(newWeeklyWorkout);

            _context.SaveChanges();

            return newWeeklyWorkout;
        }

        public void UpdateWeeklyWorkout(int id, WeeklyWorkout updatedWeeklyWorkout)
        {
            updatedWeeklyWorkout.Id = id;
            var entry = _context.Attach(updatedWeeklyWorkout);
            entry.State = EntityState.Modified;
            var saveInstace = _context.WeeklyWorkouts.SingleOrDefault(m => m.Id == updatedWeeklyWorkout.Id);

            saveInstace
                .DayOne = updatedWeeklyWorkout.DayOne;
            saveInstace
                .DayTwo = updatedWeeklyWorkout.DayTwo;
            saveInstace
                .DayThree = updatedWeeklyWorkout.DayThree;
            saveInstace
                .DayFour = updatedWeeklyWorkout.DayFour;
            saveInstace
                .DayFive = updatedWeeklyWorkout.DayFive;
            saveInstace
                .DaySix = updatedWeeklyWorkout.DaySix;
            saveInstace
                .DaySeven = updatedWeeklyWorkout.DaySeven;
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
        public void DeleteWeeklyWorkout(int id)
        {
            var weeklyWorkout = _context.WeeklyWorkouts
                .SingleOrDefault(m => m.Id == id);
            var montlyWorkout = _context.MonthlyWorkouts.Where(w =>
               (w.WeekOne.Id == weeklyWorkout.Id ||
               w.WeekTwo.Id == weeklyWorkout.Id ||
               w.WeekThree.Id == weeklyWorkout.Id ||
               w.WeekFour.Id == weeklyWorkout.Id)).SingleOrDefault();
            if (montlyWorkout == null)
                _context.WeeklyWorkouts.Remove(new WeeklyWorkout { Id = id });

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
