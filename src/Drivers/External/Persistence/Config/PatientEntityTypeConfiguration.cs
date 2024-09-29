using Entities.Patients.PatientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace External.Persistence.Config;

public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patients");

        builder.HasKey(patient => patient.Id);

        builder
            .HasOne(patient => patient.User)
            .WithOne()
            .HasForeignKey<Patient>(patient => patient.UserId)
            .IsRequired();
    }
}