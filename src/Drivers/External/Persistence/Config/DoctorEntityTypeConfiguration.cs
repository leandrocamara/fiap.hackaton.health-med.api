using Entities.Doctors.DoctorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace External.Persistence.Config;

public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("doctors");

        builder.HasKey(doctor => doctor.Id);

        builder
            .Property(d => d.Crm)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .HasOne(doctor => doctor.User)
            .WithOne(user => user.Doctor)
            .HasForeignKey<Doctor>(doctor => doctor.UserId)
            .IsRequired();
    }
}