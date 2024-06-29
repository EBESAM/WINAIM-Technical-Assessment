-- Queries to view the Appointments by the Clinic user.
SELECT 
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
    Users d ON b.DoctorId = d.ID
JOIN 
    Users u ON b.UserId = u.ID
LEFT JOIN 
    Users c ON d.ClinicID = c.ID
where d.ClinicID = 3
ORDER BY 
    b.AppointmentDate ASC,
    b.AppointmentTime ASC;
