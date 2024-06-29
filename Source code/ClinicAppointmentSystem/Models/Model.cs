using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAppointmentSystem.Models
{
    public class Model
    {

    }

    // Model class for Users table
    public class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? ClinicID { get; set; }
    }

    // Model class for Booking table
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int DoctorId { get; set; }
        public string PurposeOfVisit { get; set; }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class BookingDetails
    {
        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailID { get; set; }
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string PurposeOfVisit { get; set; }
        public string DoctorName { get; set; }
    }

    public class AppointmentDetails
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string PurposeOfVisit { get; set; }
    }

    public class ClinicAppointmentDetails
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string PurposeOfVisit { get; set; }
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
    }

    public class UserSignUpRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? ClinicID { get; set; }
    }
}