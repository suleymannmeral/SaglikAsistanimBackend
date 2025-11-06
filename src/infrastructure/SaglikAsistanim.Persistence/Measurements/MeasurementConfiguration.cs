using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.Measurements;

public sealed class MeasurementConfiguration : IEntityTypeConfiguration<Measurement>
{
    public void Configure(EntityTypeBuilder<Measurement> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.UserHealthProfileId)
            .IsRequired();  
        builder.Property(m => m.Type)
            .IsRequired();
        builder.Property(m => m.Value1)
            .IsRequired();
    }
}
