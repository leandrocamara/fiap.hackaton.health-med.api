﻿using Application.Gateways;
using Entities.Doctors.DoctorAggregate;

namespace Adapters.Gateways.Doctors;

public class DoctorGateway(IDoctorRepository doctorRepository) : IDoctorGateway
{
    public Task Save(Doctor doctor)
    {
        doctorRepository.Add(doctor);
        return Task.CompletedTask;
    }

    public Task<Doctor?> GetByCpfOrCrm(string cpf, string crm)
    {
        // TODO: Use Repository
        return Task.FromResult<Doctor>(null!)!;
    }

    public Task<Doctor?> GetByEmail(string email)
    {
        // TODO: Use Repository
        return Task.FromResult<Doctor>(null!)!;
    }

    public async Task<IEnumerable<Doctor>> GetAll()
    {
        return await doctorRepository.GetAllAsync();
    }

    public Task<Doctor?> GetById(Guid doctorId)
    {
        // TODO: Use Repository
        return Task.FromResult<Doctor>(null!)!;
    }

    public Task Update(Doctor doctor)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }

    public Task<Availability?> GetAvailabilityById(Guid availabilityId)
    {
        // TODO: Use Repository
        return Task.FromResult<Availability>(null!)!;
    }

    public Task UpdateAvailability(Availability availability)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }
}