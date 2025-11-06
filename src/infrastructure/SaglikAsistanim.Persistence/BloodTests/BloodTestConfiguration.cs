using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.BloodTests;

public sealed class BloodTestConfiguration : IEntityTypeConfiguration<BloodTest>
{
    public void Configure(EntityTypeBuilder<BloodTest> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.FilePath)
               .IsRequired()
               .HasMaxLength(500);
        builder.Property(b => b.UploadedAt).IsRequired();
        builder.Property(b => b.AnalysisResult)
               .HasColumnName("Text").IsRequired();

    }
}
