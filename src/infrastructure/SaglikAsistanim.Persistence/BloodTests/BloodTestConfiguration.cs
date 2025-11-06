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
        throw new NotImplementedException();
    }
}
