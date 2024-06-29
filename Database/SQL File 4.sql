-- Queries to view My Appointments
SELECT 
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
    where b.DoctorId = 4
ORDER BY 
    b.AppointmentDate ASC,
    b.AppointmentTime ASC;
