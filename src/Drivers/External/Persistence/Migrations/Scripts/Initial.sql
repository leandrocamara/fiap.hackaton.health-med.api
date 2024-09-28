CREATE TABLE Users (
    Id UUID PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType INT NOT NULL
);

CREATE TABLE Doctors (
    Id UUID PRIMARY KEY,
    UserId UUID NOT NULL,
    Crm VARCHAR(20) NOT NULL,
    CONSTRAINT FK_Doctor_Users FOREIGN KEY (UserId) REFERENCES Users (Id)
);

CREATE TABLE Patients (
    Id UUID PRIMARY KEY,
    UserId UUID NOT NULL,
    CreatedAt TIMESTAMP NOT NULL,
    CONSTRAINT FK_Patient_Users FOREIGN KEY (UserId) REFERENCES Users (Id)
);

CREATE TABLE Availabilities (
    Id UUID PRIMARY KEY,
    DoctorId UUID NOT NULL,
    DateTime TIMESTAMP NOT NULL,
    CONSTRAINT FK_Availability_Doctor FOREIGN KEY (DoctorId) REFERENCES Doctors (Id)
);

CREATE TABLE Appointments (
    Id UUID PRIMARY KEY,
    AvailabilityId UUID NOT NULL,
    PatientId UUID NOT NULL,
    CreatedAt TIMESTAMP NOT NULL,
    CONSTRAINT FK_Appointment_Availability FOREIGN KEY (AvailabilityId) REFERENCES Availabilities (Id),
    CONSTRAINT FK_Appointment_Patient FOREIGN KEY (PatientId) REFERENCES Patients (Id)
);


-- Inserir dados na tabela Users
INSERT INTO Users (Id, Name, Cpf, Email, Password, UserType) VALUES
('e8bde3e2-5e6d-4b6a-8e66-4d8903c2e37a', 'Alice Silva', '12345678900', 'alice.silva@example.com', MD5('senha123'), 1),
('cc4b6eeb-18ef-4fba-9c69-963b64f30d3f', 'Bruno Oliveira', '98765432100', 'bruno.oliveira@example.com', MD5('senha456'), 1),
('1f4c1ee0-004e-4a69-9e07-06f4f2b43f7a', 'Carlos Pereira', '14725836900', 'carlos.pereira@example.com', MD5('senha789'), 0);

-- Inserir dados na tabela Doctors
INSERT INTO Doctors (Id, UserId, Crm) VALUES
('d4c3f7a1-ded5-4aa7-96cb-2d80b8ee5c79', 'e8bde3e2-5e6d-4b6a-8e66-4d8903c2e37a', 'CRM12345'),
('bc4c1c1c-75d6-4e9e-a3d3-8b540d403b1f', 'cc4b6eeb-18ef-4fba-9c69-963b64f30d3f', 'CRM67890');

-- Inserir dados na tabela Patients
INSERT INTO Patients (Id, UserId, CreatedAt) VALUES
('f5fdd254-1440-4c8f-910e-45b90a0aa6d2', 'cc4b6eeb-18ef-4fba-9c69-963b64f30d3f', NOW()),
('a6180379-5d02-482b-99e1-54bc29c2e508', '1f4c1ee0-004e-4a69-9e07-06f4f2b43f7a', NOW());

-- Inserir dados na tabela Availabilities
INSERT INTO Availabilities (Id, DoctorId, DateTime) VALUES
('7f657bc5-d9c8-4c59-b1b4-29b2c865f563', 'd4c3f7a1-ded5-4aa7-96cb-2d80b8ee5c79', '2024-09-28 09:00:00'),
('5eecf69e-0bfa-4f79-a4a6-bc62bb1237f4', 'bc4c1c1c-75d6-4e9e-a3d3-8b540d403b1f', '2024-09-28 14:00:00');

-- Inserir dados na tabela Appointments
INSERT INTO Appointments (Id, AvailabilityId, PatientId, CreatedAt) VALUES
('c7e4b7a4-66c6-4d9c-8511-f1f1aa325a7b', '7f657bc5-d9c8-4c59-b1b4-29b2c865f563', 'f5fdd254-1440-4c8f-910e-45b90a0aa6d2', NOW()),
('f3e2c0ae-2b90-4cc3-9e94-bc7c1ec5c758', '5eecf69e-0bfa-4f79-a4a6-bc62bb1237f4', 'a6180379-5d02-482b-99e1-54bc29c2e508', NOW());