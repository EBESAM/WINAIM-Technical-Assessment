-- Creating the booking table
CREATE TABLE booking (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,
    DoctorId INT NOT NULL,
    PurposeOfVisit TEXT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES users(id),
    FOREIGN KEY (DoctorId) REFERENCES users(id)
);

-- Assuming users with IDs 1 and 2 exist, and a doctor with ID 3 exists

INSERT INTO booking (UserId, AppointmentDate, AppointmentTime, DoctorId, PurposeOfVisit)
VALUES (5, '2024-07-01', '10:00:00', 1, 'General Checkup');

INSERT INTO booking (UserId, AppointmentDate, AppointmentTime, DoctorId, PurposeOfVisit)
VALUES (2, '2024-07-02', '14:00:00', 4, 'Consultation for flu symptoms');

SELECT * FROM Booking





-- select * from booking;
-- drop table booking
-- truncate table booking
