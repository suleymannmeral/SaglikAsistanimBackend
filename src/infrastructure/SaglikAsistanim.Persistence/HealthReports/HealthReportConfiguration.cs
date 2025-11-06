using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.HealthReports;

public sealed class HealthReportConfiguration : IEntityTypeConfiguration<HealthReport>
{
    public void Configure(EntityTypeBuilder<HealthReport> builder)
    {
        throw new NotImplementedException();
    }
}
