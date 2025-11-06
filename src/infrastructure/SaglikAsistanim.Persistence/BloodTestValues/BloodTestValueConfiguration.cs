using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.BloodTestValues
{
    public sealed class BloodTestValueConfiguration : IEntityTypeConfiguration<BloodTest>
    {
        public void Configure(EntityTypeBuilder<BloodTest> builder)
        {
            throw new NotImplementedException();
        }
    }
}
