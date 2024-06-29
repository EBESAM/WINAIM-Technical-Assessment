-- Creating the user entity table
CREATE TABLE Users (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Firstname VARCHAR(50) NOT NULL,
    Lastname VARCHAR(50) NOT NULL,
    Gender ENUM('Male', 'Female', 'Other') NOT NULL,
    DateOfBirth DATE NOT NULL,
    Age INT NOT NULL,
    Address VARCHAR(255) NOT NULL,
    ContactNo VARCHAR(15) NOT NULL,
    EmailID VARCHAR(100) NOT NULL UNIQUE,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Role ENUM('Doctor', 'Clinic', 'User') NOT NULL,
    ClinicID INT DEFAULT NULL
);

-- Inserting sample records
INSERT INTO Users (Firstname, Lastname, Gender, DateOfBirth, Age, Address, ContactNo, EmailID, Username, Password, Role, ClinicID)
VALUES
('John', 'Doe', 'Male', '1980-05-15', 44, '1234 Elm Street', '123-456-7890', 'john.doe@example.com', 'johndoe', 'password123', 'Doctor', 3),
('Jane', 'Smith', 'Female', '1985-09-23', 38, '5678 Oak Avenue', '234-567-8901', 'jane.smith@example.com', 'janesmith', 'password456', 'User', NULL),
('Alice', 'Johnson', 'Female', '1990-01-10', 34, '910 Pine Lane', '345-678-9012', 'alice.johnson@example.com', 'alicej', 'password789', 'Clinic', NULL),
('Bob', 'Brown', 'Male', '1975-11-20', 48, '111 Maple Street', '456-789-0123', 'bob.brown@example.com', 'bobb', 'password321', 'Doctor', 3),
('Charlie', 'Davis', 'Other', '2000-07-14', 23, '222 Birch Road', '567-890-1234', 'charlie.davis@example.com', 'charlied', 'password654', 'User', NULL);

select * from users;















