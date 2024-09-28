using Entities.Patients.PatientAggregate;
using Entities.Users.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace External.Persistence.Config;

public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patients")
            .HasBaseType<User>();
    }
}
