using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.Persistence.HealthReports;

public sealed class HealthReportRepository(AppDbContext context):GenericRepository<HealthReport,int>(context), IHealthReportRepository
{
}
