using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.HealthReports;

public sealed class HealthReportRepository(AppDbContext context):GenericRepository<HealthReport,int>(context), IHealthReportRepository
{
}
