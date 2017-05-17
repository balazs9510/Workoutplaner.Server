using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Services
{
    public interface IUserService
    {
        ApplicationUser Get(string id);
    }
}
