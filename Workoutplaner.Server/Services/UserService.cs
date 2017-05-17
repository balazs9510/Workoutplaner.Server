using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Context;
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
            return _context.Users.SingleOrDefault(u => u.Id.Equals(id));
        }
    }
}
