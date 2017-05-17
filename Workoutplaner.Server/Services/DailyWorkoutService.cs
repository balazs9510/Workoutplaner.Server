using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Exceptions;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public class DailyWorkoutService : IDailyWorkoutService
    {
        private readonly WorkoutContext _context;
        public DailyWorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        public DailyWorkout GetDailyWorkout(int id,ApplicationUser user)
        {
            return _context.DailyWorkouts
                
                .Include(dw => dw.Exercises)
                .SingleOrDefault(dw => dw.Id == id) ?? throw new EntityNotFoundException("Nem található az edzés");
        }

        public IEnumerable<DailyWorkout> GetDailyWorkouts(ApplicationUser user)
        {
            return _context.DailyWorkouts
                .Include(dw => dw.Exercises)
                .Where(u=> u.UserID.Equals(user.Id))
                .ToList();
        }

        public DailyWorkout InsertDailyWorkout(DailyWorkout newDailyWorkout, ApplicationUser user)
        {
            List<ExerciseItem> exercises = new List<ExerciseItem>();
            foreach (var exercise in newDailyWorkout.Exercises)
            {
                var exerciseToSave = new ExerciseItem()
                {
                    Name = exercise.Name,
                    Reps = exercise.Reps,
                    SerialNumber = exercise.SerialNumber,
                    Description = exercise.Description,
                    MuscleGroup = exercise.MuscleGroup
                };
                _context.ExerciseItems.Add(exerciseToSave);
                exercises.Add(exerciseToSave);
            }
            var savedInstance = new DailyWorkout()
            {
                Name = newDailyWorkout.Name,
                WorkoutType = newDailyWorkout.WorkoutType,
                Exercises = exercises
            };
            savedInstance.UserID = user.Id;
            user.DailyWorkouts.Add(savedInstance);
            _context.DailyWorkouts.Add(savedInstance);

            _context.SaveChanges();

            return savedInstance;
        }

        public void UpdateDailyWorkout(int id, DailyWorkout updatedDailyWorkout)
        {
            updatedDailyWorkout.Id = id;
            var entry = _context.Attach(updatedDailyWorkout);
            entry.State = EntityState.Modified;
            var current = _context.DailyWorkouts.SingleOrDefault(m => m.Id == updatedDailyWorkout.Id);
            foreach (var exercise in updatedDailyWorkout.Exercises.ToList())
            {
                var newexercise = _context.ExerciseItems.SingleOrDefault(m => m.Id == exercise.Id);
                if (newexercise == null)
                {

                    var newElem = new ExerciseItem()
                    {
                        Description = exercise.Description,
                        Name = exercise.Name,
                        Reps = exercise.Reps,
                        SerialNumber = exercise.SerialNumber,
                        MuscleGroup = exercise.MuscleGroup
                    };
                    _context.ExerciseItems.Add(newElem);
                    current.Exercises.Add(newElem);
                }
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Létezett-e egyáltalán
                var _ = _context.DailyWorkouts.AsNoTracking().SingleOrDefault(p => p.Id == id) 
                    ?? throw new EntityNotFoundException("Nem található az edzés");

                throw;
            }
        }
        public void DeleteDailyWorkout(int id, ApplicationUser user)
        {
            var weeklyWorkout =  _context.WeeklyWorkouts.Where(
                w => (w.DayOne.Id == id ||
                w.DayTwo.Id == id ||
                w.DayThree.Id == id ||
                w.DayFour.Id == id ||
                w.DayFive.Id == id ||
                w.DaySix.Id == id ||
                w.DaySeven.Id == id
                )).FirstOrDefault();
            if (weeklyWorkout == null)
            {
                var deleteInstance = _context.DailyWorkouts
                    .Include(p=>p.Exercises)
                    .SingleOrDefault(p => p.Id == id);
                foreach (var exerciseItem in deleteInstance.Exercises)
                {
                    _context.ExerciseItems.Remove(exerciseItem);
                }
                user.DailyWorkouts.Remove(deleteInstance);
                _context.DailyWorkouts.Remove(deleteInstance);
            }
            else throw new EntityCannotDeleteException();
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _ = _context.DailyWorkouts.AsNoTracking().SingleOrDefault(p => p.Id == id) 
                    ?? throw new EntityNotFoundException("Nem található az edzés");

                throw;
            }
        }

       
    }
}
