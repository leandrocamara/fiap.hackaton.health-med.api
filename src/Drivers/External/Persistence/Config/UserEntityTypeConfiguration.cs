using Entities.Doctors.DoctorAggregate;
using Entities.Patients.PatientAggregate;
using Entities.Users.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace External.Persistence.Config;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(user => user.Cpf)
            .HasMaxLength(11)
            .IsRequired(); // CPF deve ter 11 dígitos

        builder
            .Property(user => user.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasIndex(user => user.Email)
            .IsUnique(); 

        builder
            .Property(user => user.Password)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(user => user.CreatedAt)
            .IsRequired();
    }
}