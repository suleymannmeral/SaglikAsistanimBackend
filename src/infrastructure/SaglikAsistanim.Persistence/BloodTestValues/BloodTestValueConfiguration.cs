using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.BloodTestValues;

public sealed class BloodTestValueConfiguration : IEntityTypeConfiguration<BloodTestValue>
{
    public void Configure(EntityTypeBuilder<BloodTestValue> builder)
    {
       builder.HasKey(b => b.Id);   
        builder.Property(b=>b.TestName).IsRequired().HasMaxLength(100); 
        builder.Property(b=>b.Value).IsRequired().HasMaxLength(10);
        builder.Property(b=>b.Unit).IsRequired().HasMaxLength(20);
        builder.Property(b=>b.ReferenceRange).HasMaxLength(50);
        builder.Property(b=>b.Status).HasMaxLength(20);

        builder.HasOne(x => x.BloodTest)
               .WithMany(x => x.Values)
               .HasForeignKey(x => x.BloodTestId)
               .OnDelete(DeleteBehavior.Cascade);



    }
}
