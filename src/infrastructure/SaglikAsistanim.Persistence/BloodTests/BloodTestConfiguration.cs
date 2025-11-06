using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.BloodTests;

public sealed class BloodTestConfiguration : IEntityTypeConfiguration<BloodTest>
{
    public void Configure(EntityTypeBuilder<BloodTest> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserHealthProfileId).IsRequired();
        builder.Property(b => b.FilePath)
               .IsRequired()
               .HasMaxLength(500);
        builder.Property(b => b.UploadedAt).IsRequired();
        builder.Property(b => b.AnalysisResult)
               .HasColumnName("Text").IsRequired();


    }
}
