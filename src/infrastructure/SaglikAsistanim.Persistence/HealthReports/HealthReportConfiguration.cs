using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.HealthReports;

public sealed class HealthReportConfiguration : IEntityTypeConfiguration<HealthReport>
{
    public void Configure(EntityTypeBuilder<HealthReport> builder)
    {
        builder.HasKey(hr => hr.Id);
        builder.Property(hr => hr.UserHealthProfileId).IsRequired();
        builder.Property(hr => hr.ReportDate).IsRequired();
        builder.Property(hr => hr.Summary).IsRequired().HasColumnType("text");
        builder.Property(hr => hr.Recommendations).IsRequired().HasColumnType("text");
        builder.Property(hr => hr.HealthScore).IsRequired();
    }
}
