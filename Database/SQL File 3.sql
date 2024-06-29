-- Queries for Book Appointment
SELECT 
    u.ID AS UserID,
    u.Firstname,
    u.Lastname,
    u.EmailID,
    b.id AS BookingID,
    b.AppointmentDate AS BookingDate,
    b.AppointmentTime AS BookingTime,
    b.PurposeOfVisit AS PurposeOfVisit,
    d.id,
    CONCAT(d.Firstname, ' ', d.Lastname) AS DoctorName
FROM 
    booking b
JOIN 
    users u ON b.UserId = u.ID
LEFT JOIN 
    users d ON b.UserId = d.ID
WHERE 
    u.Role = 'User' and u.Id = 5;
    
-- Queries for My Appointments
SELECT 
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
    and u.Id = 5
ORDER BY 
    b.AppointmentDate ASC,
    b.AppointmentTime ASC
LIMIT 1;

