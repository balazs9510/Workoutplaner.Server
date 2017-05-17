using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Workoutplaner.Server.Context;
using Newtonsoft.Json;

namespace Workoutplaner.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly WorkoutContext _context;
        public AccountsController(WorkoutContext context)
        {
            _context = context;
        }
        [HttpGet("{email}")]
        public IActionResult ExistUser(string email)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email.Equals(email));
            if(user == null)
                return Ok(false);
            else
                return Ok(true);

        }
        
    }
}