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
    public class UsersController : ApiController
    {
        private readonly ClinicMgmtContext _context;

        public UsersController()
        {
            _context = new ClinicMgmtContext(); // Initialize your context here
        }

        // GET: api/users
        public IHttpActionResult GetUsers()
        {
            var users = _context.GetUsers(); // Implement GetUsers() method in your ClinicMgmtContext
            return Ok(users);
        }

        // GET: api/users/5
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.GetUserById(id); // Implement GetUserById(int id) method

            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            return Ok(user);
        }

        // POST: api/users
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request with validation errors
            }

            _context.AddUser(user); // Implement AddUser(User user) method

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user); // Return 201 Created
        }

        // PUT: api/users/5
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid || id != user.ID)
            {
                return BadRequest(); // Return 400 Bad Request if IDs don't match or model state is invalid
            }

            _context.UpdateUser(user); // Implement UpdateUser(User user) method

            return StatusCode(HttpStatusCode.NoContent); // Return 204 No Content
        }

        // DELETE: api/users/5
        public IHttpActionResult DeleteUser(int id)
        {
            var user = _context.GetUserById(id);

            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            _context.DeleteUser(id); // Implement DeleteUser(int id) method

            return StatusCode(HttpStatusCode.NoContent); // Return 204 No Content
        }
    }
}