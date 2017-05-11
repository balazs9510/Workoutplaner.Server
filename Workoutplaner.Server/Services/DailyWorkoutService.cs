using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models;

namespace Workoutplaner.Server.Services
{
    public class DailyWorkoutService : IDailyWorkoutService
    {
        private readonly WorkoutContext _context;
        public DailyWorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        public DailyWorkout GetDailyWorkout(int id)
        {
            return _context.DailyWorkouts
                .Include(dw => dw.Exercises)
                .SingleOrDefault(dw => dw.Id == id) ?? throw new EntityNotFoundException("Nem található az edzés");
        }

        public IEnumerable<DailyWorkout> GetDailyWorkouts()
        {
            return _context.DailyWorkouts
                .Include(dw => dw.Exercises)
                .ToList();
        }

        public DailyWorkout InsertDailyWorkout(DailyWorkout newDailyWorkout)
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
        public void DeleteDailyWorkout(int id)
        {
            _context.DailyWorkouts.Remove(new DailyWorkout { Id = id });

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
