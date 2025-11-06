using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.Medications;

public sealed class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.DrugName)
               .IsRequired()
               .HasMaxLength(200);
        builder.Property(m => m.Frequency).IsRequired();
        builder.Property(m => m.StartDate).IsRequired();
        builder.Property(m => m.EndDate);
        builder.Property(m=> m.IsActive)
               .IsRequired()
               .HasDefaultValue(true);
    }
}
