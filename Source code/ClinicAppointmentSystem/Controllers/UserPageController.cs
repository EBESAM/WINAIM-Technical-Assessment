using System.Web.Mvc;
using ClinicAppointmentSystem.DAL;
using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Controllers
{
    public class UserPageController : Controller
    {
        private readonly ClinicMgmtContext _context;

        public UserPageController()
        {
            _context = new ClinicMgmtContext();
        }

        // GET: UserPage
        public ActionResult Index()
        {
            var user = (User)Session["User"];
            if (user != null)
            {
                var nextBooking = _context.GetNextUserBooking(user.ID);
                var bookingDetails = _context.GetUserBookingDetails(user.ID);
                ViewBag.NextBooking = nextBooking;
                ViewBag.BookingDetails = bookingDetails;
                return View(user);
            }
            return RedirectToAction("Login", "Account");
        }

        // GET: UserPage
        public ActionResult DoctorView()
        {

            var doc = (User)Session["User"];
            if (doc != null)
            {
    

                var appointments = _context.GetDoctorAppointments(doc.ID);
                ViewBag.Appointments = appointments;
 
                return View(doc);
            }
            return RedirectToAction("Login", "Account");
        }


        public ActionResult ClinicView()
        {

            var clinic = (User)Session["User"];
            if (clinic != null)
            {


                var appointments = _context.GetClinicAppointments(clinic.ID);
                ViewBag.Appointments = appointments;

                return View(clinic);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
