using ClinicAppointmentSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicAppointmentSystem.DAL
{
    public class ClinicMgmtContext
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        // Methods for Users table
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Users";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                ID = reader.GetInt32("ID"),
                                Firstname = reader.GetString("Firstname"),
                                Lastname = reader.GetString("Lastname"),
                                Gender = reader.GetString("Gender"),
                                DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                Age = reader.GetInt32("Age"),
                                Address = reader.GetString("Address"),
                                ContactNo = reader.GetString("ContactNo"),
                                EmailID = reader.GetString("EmailID"),
                                Username = reader.GetString("Username"),
                                Password = reader.GetString("Password"),
                                Role = reader.GetString("Role"),
                                ClinicID = reader.IsDBNull(reader.GetOrdinal("ClinicID")) ? (int?)null : reader.GetInt32("ClinicID")
                            });
                        }
                    }
                }
            }
            return users;
        }

        public User GetUserById(int id)
        {
            User user = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Users WHERE ID = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                ID = reader.GetInt32("ID"),
                                Firstname = reader.GetString("Firstname"),
                                Lastname = reader.GetString("Lastname"),
                                Gender = reader.GetString("Gender"),
                                DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                Age = reader.GetInt32("Age"),
                                Address = reader.GetString("Address"),
                                ContactNo = reader.GetString("ContactNo"),
                                EmailID = reader.GetString("EmailID"),
                                Username = reader.GetString("Username"),
                                Password = reader.GetString("Password"),
                                Role = reader.GetString("Role"),
                                ClinicID = reader.IsDBNull(reader.GetOrdinal("ClinicID")) ? (int?)null : reader.GetInt32("ClinicID")
                            };
                        }
                    }
                }
            }
            return user;
        }

        public void AddUser(User user)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO Users (Firstname, Lastname, Gender, DateOfBirth, Age, Address, ContactNo, EmailID, Username, Password, Role, ClinicID) VALUES (@Firstname, @Lastname, @Gender, @DateOfBirth, @Age, @Address, @ContactNo, @EmailID, @Username, @Password, @Role, @ClinicID)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@EmailID", user.EmailID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@ClinicID", user.ClinicID.HasValue ? (object)user.ClinicID.Value : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "UPDATE Users SET Firstname = @Firstname, Lastname = @Lastname, Gender = @Gender, DateOfBirth = @DateOfBirth, Age = @Age, Address = @Address, ContactNo = @ContactNo, EmailID = @EmailID, Username = @Username, Password = @Password, Role = @Role, ClinicID = @ClinicID WHERE ID = @ID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", user.ID);
                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@EmailID", user.EmailID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@ClinicID", user.ClinicID.HasValue ? (object)user.ClinicID.Value : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "DELETE FROM Users WHERE ID = @ID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Methods for Booking table
        public IEnumerable<Booking> GetBookings()
        {
            var bookings = new List<Booking>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Booking";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                AppointmentDate = reader.GetDateTime("AppointmentDate"),
                                AppointmentTime = reader.GetTimeSpan("AppointmentTime"),
                                DoctorId = reader.GetInt32("DoctorId"),
                                PurposeOfVisit = reader.GetString("PurposeOfVisit")
                            });
                        }
                    }
                }
            }
            return bookings;
        }

        public Booking GetBookingById(int id)
        {
            Booking booking = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Booking WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new Booking
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                AppointmentDate = reader.GetDateTime("AppointmentDate"),
                                AppointmentTime = reader.GetTimeSpan("AppointmentTime"),
                                DoctorId = reader.GetInt32("DoctorId"),
                                PurposeOfVisit = reader.GetString("PurposeOfVisit")
                            };
                        }
                    }
                }
            }
            return booking;
        }

        public void AddBooking(Booking booking)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO Booking (UserId, AppointmentDate, AppointmentTime, DoctorId, PurposeOfVisit) VALUES (@UserId, @AppointmentDate, @AppointmentTime, @DoctorId, @PurposeOfVisit)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", booking.UserId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", booking.AppointmentDate);
                    cmd.Parameters.AddWithValue("@AppointmentTime", booking.AppointmentTime);
                    cmd.Parameters.AddWithValue("@DoctorId", booking.DoctorId);
                    cmd.Parameters.AddWithValue("@PurposeOfVisit", booking.PurposeOfVisit);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBooking(Booking booking)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "UPDATE Booking SET UserId = @UserId, AppointmentDate = @AppointmentDate, AppointmentTime = @AppointmentTime, DoctorId = @DoctorId, PurposeOfVisit = @PurposeOfVisit WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", booking.Id);
                    cmd.Parameters.AddWithValue("@UserId", booking.UserId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", booking.AppointmentDate);
                    cmd.Parameters.AddWithValue("@AppointmentTime", booking.AppointmentTime);
                    cmd.Parameters.AddWithValue("@DoctorId", booking.DoctorId);
                    cmd.Parameters.AddWithValue("@PurposeOfVisit", booking.PurposeOfVisit);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBooking(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "DELETE FROM Booking WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public bool ValidateUser(string username, string password)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    var result = (long)cmd.ExecuteScalar();
                    return result > 0;
                }
            }
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Users WHERE Username = @Username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                ID = reader.GetInt32("ID"),
                                Firstname = reader.GetString("Firstname"),
                                Lastname = reader.GetString("Lastname"),
                                Gender = reader.GetString("Gender"),
                                DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                Age = reader.GetInt32("Age"),
                                Address = reader.GetString("Address"),
                                ContactNo = reader.GetString("ContactNo"),
                                EmailID = reader.GetString("EmailID"),
                                Username = reader.GetString("Username"),
                                Password = reader.GetString("Password"),
                                Role = reader.GetString("Role"),
                                ClinicID = reader.IsDBNull(reader.GetOrdinal("ClinicID")) ? (int?)null : reader.GetInt32("ClinicID")
                            };
                        }
                    }
                }
            }
            return user;
        }

        public BookingDetails GetNextUserBooking(int userId)
        {
            BookingDetails nextBooking = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"SELECT 
                                u.ID AS UserID,
                                u.Firstname,
                                u.Lastname,
                                u.EmailID,
                                b.id AS BookingID,
                                b.AppointmentDate AS BookingDate,
                                b.AppointmentTime AS BookingTime,
                                b.PurposeOfVisit AS PurposeOfVisit,
                                d.Id,
                                CONCAT(d.Firstname, ' ', d.Lastname) AS DoctorName
                              FROM 
                                booking b
                              JOIN 
                                users u ON b.UserId = u.Id
                              LEFT JOIN 
                                users d ON b.DoctorId = d.Id
                              WHERE 
                                u.Role = 'User'
                                AND b.AppointmentDate >= CURDATE()
                                AND u.Id = @UserId
                              ORDER BY 
                                b.AppointmentDate ASC,
                                b.AppointmentTime ASC
                              LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nextBooking = new BookingDetails
                            {
                                UserID = reader.GetInt32("UserID"),
                                Firstname = reader.GetString("Firstname"),
                                Lastname = reader.GetString("Lastname"),
                                EmailID = reader.GetString("EmailID"),
                                BookingID = reader.GetInt32("BookingID"),
                                BookingDate = reader.GetDateTime("BookingDate"),
                                BookingTime = reader.GetTimeSpan("BookingTime"),
                                PurposeOfVisit = reader.GetString("PurposeOfVisit"),
                                DoctorName = reader.GetString("DoctorName")
                            };
                        }
                    }
                }
            }
            return nextBooking;
        }

        public List<BookingDetails> GetUserBookingDetails(int userId)
        {
            var bookingDetails = new List<BookingDetails>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"SELECT 
                                u.ID AS UserID,
                                u.Firstname,
                                u.Lastname,
                                u.EmailID,
                                b.id AS BookingID,
                                b.AppointmentDate AS BookingDate,
                                b.AppointmentTime AS BookingTime,
                                b.PurposeOfVisit AS PurposeOfVisit,
                                d.id AS DoctorID,
                                CONCAT(d.Firstname, ' ', d.Lastname) AS DoctorName
                              FROM 
                                booking b
                              JOIN 
                                users u ON b.UserId = u.Id
                              LEFT JOIN 
                                users d ON b.DoctorId = d.Id
                              WHERE 
                                u.Role = 'User'
                                AND u.Id = @UserId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookingDetails.Add(new BookingDetails
                            {
                                UserID = reader.GetInt32("UserID"),
                                Firstname = reader.GetString("Firstname"),
                                Lastname = reader.GetString("Lastname"),
                                EmailID = reader.GetString("EmailID"),
                                BookingID = reader.GetInt32("BookingID"),
                                BookingDate = reader.GetDateTime("BookingDate"),
                                BookingTime = reader.GetTimeSpan("BookingTime"),
                                PurposeOfVisit = reader.GetString("PurposeOfVisit"),
                                DoctorName = reader.GetString("DoctorName")
                            });
                        }
                    }
                }
            }
            return bookingDetails;
        }

        public List<AppointmentDetails> GetDoctorAppointments(int doctorId)
        {
            var appointments = new List<AppointmentDetails>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"SELECT 
                                d.ID AS DoctorID,
                                CONCAT(d.Firstname, ' ', d.Lastname) AS DoctorName,
                                u.ID AS UserID,
                                CONCAT(u.Firstname, ' ', u.Lastname) AS UserName,
                                b.id AS BookingID,
                                b.AppointmentDate AS BookingDate,
                                b.AppointmentTime AS BookingTime,
                                b.PurposeOfVisit AS PurposeOfVisit
                              FROM 
                                booking b
                              JOIN 
                                users d ON b.DoctorId = d.ID
                              JOIN 
                                users u ON b.UserId = u.ID
                              WHERE
                                d.ID = @DoctorId
                              ORDER BY 
                                b.AppointmentDate ASC,
                                b.AppointmentTime ASC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new AppointmentDetails
                            {
                                DoctorID = reader.GetInt32("DoctorID"),
                                DoctorName = reader.GetString("DoctorName"),
                                UserID = reader.GetInt32("UserID"),
                                UserName = reader.GetString("UserName"),
                                BookingID = reader.GetInt32("BookingID"),
                                BookingDate = reader.GetDateTime("BookingDate"),
                                BookingTime = reader.GetTimeSpan("BookingTime"),
                                PurposeOfVisit = reader.GetString("PurposeOfVisit")
                            });
                        }
                    }
                }
            }
            return appointments;
        }

        public List<ClinicAppointmentDetails> GetClinicAppointments(int clinicId)
        {
            var appointments = new List<ClinicAppointmentDetails>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = @"SELECT 
                                d.ID AS DoctorID,
                                CONCAT(d.Firstname, ' ', d.Lastname) AS DoctorName,
                                u.ID AS UserID,
                                CONCAT(u.Firstname, ' ', u.Lastname) AS UserName,
                                b.id AS BookingID,
                                b.AppointmentDate AS BookingDate,
                                b.AppointmentTime AS BookingTime,
                                b.PurposeOfVisit AS PurposeOfVisit,
                                c.ID AS ClinicID,
                                c.Firstname AS ClinicName
                              FROM 
                                booking b
                              JOIN 
                                users d ON b.DoctorId = d.ID
                              JOIN 
                                users u ON b.UserId = u.ID
                              LEFT JOIN 
                                users c ON d.ClinicID = c.ID
                              WHERE
                                d.ClinicID = @ClinicId
                              ORDER BY 
                                b.AppointmentDate ASC,
                                b.AppointmentTime ASC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClinicId", clinicId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new ClinicAppointmentDetails
                            {
                                DoctorID = reader.GetInt32("DoctorID"),
                                DoctorName = reader.GetString("DoctorName"),
                                UserID = reader.GetInt32("UserID"),
                                UserName = reader.GetString("UserName"),
                                BookingID = reader.GetInt32("BookingID"),
                                BookingDate = reader.GetDateTime("BookingDate"),
                                BookingTime = reader.GetTimeSpan("BookingTime"),
                                PurposeOfVisit = reader.GetString("PurposeOfVisit"),
                                ClinicID = reader.GetInt32("ClinicID"),
                                ClinicName = reader.GetString("ClinicName")
                            });
                        }
                    }
                }
            }
            return appointments;
        }
    }
}