using ClinicAppointmentSystem.DAL;
using ClinicAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClinicAppointmentSystem.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ClinicMgmtContext _context;

        public LoginController()
        {
            _context = new ClinicMgmtContext();
        }

        // POST: api/login
        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid login request.");
            }

            bool isValidUser = _context.ValidateUser(loginRequest.Username, loginRequest.Password);
            if (!isValidUser)
            {
                return Unauthorized();
            }

            User user = _context.GetUserByUsername(loginRequest.Username);
            return Ok(new { Message = "Login successful!", User = user });
        }
    }
}

