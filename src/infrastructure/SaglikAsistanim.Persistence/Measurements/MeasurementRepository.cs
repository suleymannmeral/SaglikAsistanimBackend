using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.Persistence.Measurements;

public sealed class MeasurementRepository(AppDbContext context):GenericRepository<Measurement,int>(context), IMeasurementRepository
{
}
