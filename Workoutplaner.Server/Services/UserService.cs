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
    public class UserService : IUserService
    {
        private readonly WorkoutContext _context;
        public UserService(WorkoutContext context)
        {
            _context = context;

        }
        public ApplicationUser Get(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(id));
            return user;
        }

        public void InsertDoneWorkout(DoneDailyWorkout newWorkout, ApplicationUser user)
        {
            
            user.DonedDailyWorkouts.Add(newWorkout);
            newWorkout.UserId = user.Id;
            _context.DonedDailyWorkouts.Add(newWorkout);
            _context.SaveChanges();
        }
    }
}
