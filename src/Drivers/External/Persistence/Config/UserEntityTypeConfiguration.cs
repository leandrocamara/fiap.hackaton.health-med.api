using Entities.Doctors.DoctorAggregate;
using Entities.Patients.PatientAggregate;
using Entities.Users.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace External.Persistence.Config;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        //.HasDiscriminator<UserType>("UserType")
        //.HasValue<Doctor>(UserType.Doctor)
        //.HasValue<Patient>(UserType.Patient);

        builder.HasKey(users => users.Id);

        builder.Property(u => u.Name)
           .IsRequired()
           .HasMaxLength(255); 

        builder.Property(u => u.Cpf)
            .IsRequired()
            .HasMaxLength(11); // CPF deve ter 11 dígitos
        

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255); 

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255); 

    }
}