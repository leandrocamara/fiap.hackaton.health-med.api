using Entities.Doctors.DoctorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace External.Persistence.Config;

public class AvailabilityEntityTypeConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.ToTable("availabilities");

        builder.HasKey(availability => availability.Id);

        builder
            .Property(availability => availability.DateTime)
            .IsRequired();
    }
}