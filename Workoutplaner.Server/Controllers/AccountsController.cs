using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Workoutplaner.Server.Context;
using Newtonsoft.Json;
using Workoutplaner.Server.Models;
using Workoutplaner.Server.Services;
using Microsoft.AspNetCore.Identity;
using Workoutplaner.Server.Models.Identity;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    [ApiVersion("2.0")]
    public class AccountsController : BaseController
    {
        private readonly IUserService _userService;
        public AccountsController(IUserService userService,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor accessor,
            WorkoutContext cotnext)
            : base(userManager, accessor, cotnext)
        {
            _userService  = userService;
        }
        [HttpGet("{email}")]
        [MapToApiVersion("2.0")]
        public IActionResult ExistUser(string email)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email.Equals(email));
            if(user == null)
                return Ok(false);
            else
                return Ok(true);

        }
        [HttpPost]
        [MapToApiVersion("2.0")]
        public  IActionResult DoneWorkout([FromBody] DoneDailyWorkout dw)
        {
            try
            {
                _userService.InsertDoneWorkout(dw, _user);
            }catch (Exception) { return BadRequest(); }
       
            return Ok();
        }

    }
}