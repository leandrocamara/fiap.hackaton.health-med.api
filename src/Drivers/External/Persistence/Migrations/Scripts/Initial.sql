CREATE
EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "users" (
    "Id"        UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "Name"      VARCHAR(255) NOT NULL,
    "Cpf"       VARCHAR(11) NOT NULL,
    "Email"     VARCHAR(255) NOT NULL,
    "Password"  VARCHAR(255) NOT NULL,
    "CreatedAt" TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE "doctors" (
    "Id"        UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "UserId"    UUID NOT NULL,
    "Crm"       VARCHAR(20) NOT NULL,
    FOREIGN KEY ("UserId") REFERENCES "users" ("Id")
);

CREATE TABLE "patients" (
    "Id"        UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "UserId"    UUID NOT NULL,
    FOREIGN KEY ("UserId") REFERENCES "users" ("Id")
);

CREATE TABLE "availabilities" (
    "Id"        UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "DoctorId"  UUID NOT NULL,
    "DateTime"  TIMESTAMP NOT NULL,
    FOREIGN KEY ("DoctorId") REFERENCES "doctors" ("Id")
);

CREATE TABLE Appointments (
    "Id"                UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "AvailabilityId"    UUID NOT NULL,
    "PatientId"         UUID NOT NULL,
    "CreatedAt"         TIMESTAMP NOT NULL,
    FOREIGN KEY ("AvailabilityId") REFERENCES "availabilities" ("Id"),
    FOREIGN KEY ("PatientId") REFERENCES "patients" ("Id")
);


-- Inserir dados na tabela Users
INSERT INTO "users" ("Id", "Name", "Cpf", "Email", "Password") VALUES
('e8bde3e2-5e6d-4b6a-8e66-4d8903c2e37a', 'Alice Silva', '12345678900', 'alice.silva@example.com', MD5('senha123')),
('cc4b6eeb-18ef-4fba-9c69-963b64f30d3f', 'Bruno Oliveira', '98765432100', 'bruno.oliveira@example.com', MD5('senha456')),
('1f4c1ee0-004e-4a69-9e07-06f4f2b43f7a', 'Carlos Pereira', '14725836900', 'carlos.pereira@example.com', MD5('senha789')),
('2e9f6ed0-1e3a-4eb5-a3b7-c74f2e598d30', 'Daniela Rocha', '25836914700', 'daniela.rocha@example.com', MD5('senha012')),
('5a8f6b35-413f-4b6a-85bc-2b3a739bebcd', 'Eduardo Costa', '96385274100', 'eduardo.costa@example.com', MD5('senha345')),
('4e2fd826-6b5b-4f2b-b934-1d62f9e51724', 'Fernanda Lima', '11223344556', 'fernanda.lima@example.com', MD5('senha678')),
('ca2f5e6a-4501-4d61-8a53-b27aaf63a7d6', 'Gabriel Souza', '66554433221', 'gabriel.souza@example.com', MD5('senha901')),
('ee3c2a21-51f3-44f6-bc9e-9e2c6ef7c121', 'Helena Ferreira', '77889900112', 'helena.ferreira@example.com', MD5('senha234')),
('9ac3b6d4-d14e-49f3-b3c5-1f22e15e6479', 'Igor Santos', '99887766554', 'igor.santos@example.com', MD5('senha567')),
('ae2b7d61-f142-41d2-b3d9-ea0f59d92b10', 'Juliana Mendes', '44332211009', 'juliana.mendes@example.com', MD5('senha890'));

-- Inserir dados na tabela Doctors
INSERT INTO "doctors" ("Id", "UserId", "Crm") VALUES
('d4c3f7a1-ded5-4aa7-96cb-2d80b8ee5c79', 'e8bde3e2-5e6d-4b6a-8e66-4d8903c2e37a', 'CRM12345'),
('bc4c1c1c-75d6-4e9e-a3d3-8b540d403b1f', 'cc4b6eeb-18ef-4fba-9c69-963b64f30d3f', 'CRM67890'),
('c9f1d2c1-8cb2-488b-bb68-2ff4a69d5e93', '1f4c1ee0-004e-4a69-9e07-06f4f2b43f7a', 'CRM11223'),
('a0e1b6c4-b7cf-41ff-8543-9852f59a4e3d', '2e9f6ed0-1e3a-4eb5-a3b7-c74f2e598d30', 'CRM44556'),
('f8e2a5f0-4165-45e3-9bb2-6eec72f1c7c9', '5a8f6b35-413f-4b6a-85bc-2b3a739bebcd', 'CRM77889');

-- Inserir dados na tabela Patients
INSERT INTO "patients" ("Id", "UserId") VALUES
('f5fdd254-1440-4c8f-910e-45b90a0aa6d2', '4e2fd826-6b5b-4f2b-b934-1d62f9e51724'),
('e7f1a543-2e49-4c88-9512-4f93977e6c41', 'ca2f5e6a-4501-4d61-8a53-b27aaf63a7d6'),
('a6180379-5d02-482b-99e1-54bc29c2e508', 'ee3c2a21-51f3-44f6-bc9e-9e2c6ef7c121'),
('b2c2c154-2a3b-43b1-9b8a-8e9dfd6470f7', '9ac3b6d4-d14e-49f3-b3c5-1f22e15e6479'),
('d4b1a625-8a11-4fc8-8acb-1d41263a9e6a', 'ae2b7d61-f142-41d2-b3d9-ea0f59d92b10'),
('3947a715-15c3-4407-8466-c3bf7924119f', 'e8bde3e2-5e6d-4b6a-8e66-4d8903c2e37a'),
('800cc07a-02fd-4697-8f3f-ae72990dd1b5', 'cc4b6eeb-18ef-4fba-9c69-963b64f30d3f');

-- Inserir dados na tabela Availabilities
INSERT INTO "availabilities" ("Id", "DoctorId", "DateTime") VALUES
('7f657bc5-d9c8-4c59-b1b4-29b2c865f563', 'd4c3f7a1-ded5-4aa7-96cb-2d80b8ee5c79', '2024-09-28 09:00:00'),
('5eecf69e-0bfa-4f79-a4a6-bc62bb1237f4', 'bc4c1c1c-75d6-4e9e-a3d3-8b540d403b1f', '2024-09-28 14:00:00'),
('c6a6d2e5-81f8-4fd1-bbfd-91c6a7eb96c6', 'c9f1d2c1-8cb2-488b-bb68-2ff4a69d5e93', '2024-09-29 10:00:00'),
('b2c8e1b1-1423-4a1e-8e9a-8f6b37c3b2d8', 'a0e1b6c4-b7cf-41ff-8543-9852f59a4e3d', '2024-09-29 16:00:00'),
('d4a7f6e1-85e3-49eb-9483-f52d8f0a0a54', 'f8e2a5f0-4165-45e3-9bb2-6eec72f1c7c9', '2024-09-30 11:00:00');
