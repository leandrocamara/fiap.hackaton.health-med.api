using Entities.Doctors.DoctorAggregate;

namespace Application.Gateways;

public interface IDoctorGateway
{
    Task Save(Doctor doctor);
    Task<Doctor?> GetByCpfOrCrm(string cpf, string crm);
    Task<Doctor?> GetByEmail(string email);
    Task<IEnumerable<Doctor>> GetAll();
    Task<Doctor?> GetById(Guid doctorId);
    Task Update(Doctor doctor);
}