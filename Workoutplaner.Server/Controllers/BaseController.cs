using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Models.Identity;
using Workoutplaner.Server.Services;

namespace Workoutplaner.Server.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        protected ApplicationUser _user;
        private readonly WorkoutContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseController(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor accessor,
            WorkoutContext cotnext)
        {
            _userManager = userManager;
            _httpContextAccessor = accessor;
            _context = cotnext;
            _user = _context.Users
                .Include(u=>u.DailyWorkouts)
                .Include(u => u.MonthlyWorkouts)
                .Include(u => u.WeeklyWorkouts)
                .SingleOrDefault(u => u.UserName
                .Equals(_httpContextAccessor.HttpContext.User.Identity.Name));
        }
    }
}
