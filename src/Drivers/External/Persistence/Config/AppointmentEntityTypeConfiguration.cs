using Entities.Appointments.AppointmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace External.Persistence.Config;

public class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointments");

        builder.HasKey(appointment => appointment.Id);

        builder
            .Property(appointment => appointment.CreatedAt)
            .IsRequired();

        builder
            .HasOne(appointment => appointment.Availability)
            .WithOne()
            .HasForeignKey<Appointment>(appointment => appointment.AvailabilityId)
            .IsRequired();

        builder
            .HasOne(appointment => appointment.Patient)
            .WithMany()
            .HasForeignKey(appointment => appointment.PatientId)
            .IsRequired();
    }
}