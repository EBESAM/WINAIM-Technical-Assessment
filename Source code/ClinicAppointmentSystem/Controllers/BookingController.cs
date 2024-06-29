using ClinicAppointmentSystem.DAL;
using ClinicAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ClinicAppointmentSystem.Controllers
{
    public class BookingController : ApiController
    {
        private readonly ClinicMgmtContext _context;

        public BookingController()
        {
            _context = new ClinicMgmtContext(); // Initialize your context here
        }

        // GET: api/bookings
        public IHttpActionResult GetBookings()
        {
            var bookings = _context.GetBookings(); // Implement GetBookings() method in your ClinicMgmtContext
            return Ok(bookings);
        }

        // GET: api/bookings/5
        public IHttpActionResult GetBooking(int id)
        {
            var booking = _context.GetBookingById(id); // Implement GetBookingById(int id) method

            if (booking == null)
            {
                return NotFound(); // Return 404 if booking not found
            }

            return Ok(booking);
        }

        // POST: api/bookings
        public IHttpActionResult PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request with validation errors
            }

            _context.AddBooking(booking); // Implement AddBooking(Booking booking) method

            return CreatedAtRoute("DefaultApi", new { id = booking.Id }, booking); // Return 201 Created
        }

        // PUT: api/bookings/5
        public IHttpActionResult PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid || id != booking.Id)
            {
                return BadRequest(); // Return 400 Bad Request if IDs don't match or model state is invalid
            }

            _context.UpdateBooking(booking); // Implement UpdateBooking(Booking booking) method

            return StatusCode(HttpStatusCode.NoContent); // Return 204 No Content
        }

        // DELETE: api/bookings/5
        public IHttpActionResult DeleteBooking(int id)
        {
            var booking = _context.GetBookingById(id);

            if (booking == null)
            {
                return NotFound(); // Return 404 if booking not found
            }

            _context.DeleteBooking(id); // Implement DeleteBooking(int id) method

            return StatusCode(HttpStatusCode.NoContent); // Return 204 No Content
        }
    }
}