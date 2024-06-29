using ClinicAppointmentSystem.DAL;
using ClinicAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicAppointmentSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ClinicMgmtContext _context;

        public AccountController()
        {
            _context = new ClinicMgmtContext();
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = _context.ValidateUser(loginRequest.Username, loginRequest.Password);
                if (isValidUser)
                {
                    User user = _context.GetUserByUsername(loginRequest.Username);
                    Session["User"] = user;
                    if(user.Role == "Doctor")
                    {
                        return RedirectToAction("DoctorView", "UserPage");
                    }
                    if (user.Role == "Clinic")
                    {
                        return RedirectToAction("ClinicView", "UserPage");
                    }
                    else
                    {
                        return RedirectToAction("Index", "UserPage");
                    }
                    
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(loginRequest);
        }

        // GET: Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Account");
        }


    }
}