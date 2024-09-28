using Application.UseCases.Auth;
using Entities.Doctors.DoctorAggregate;
using Entities.Users.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace External.Persistence.Config;

public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("doctors")
        .HasBaseType<User>();

        builder.Property(d => d.Crm)
           .IsRequired()
           .HasMaxLength(20);

    }
}
