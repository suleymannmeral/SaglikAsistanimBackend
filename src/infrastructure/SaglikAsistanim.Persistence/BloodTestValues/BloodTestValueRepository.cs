using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;
namespace SaglikAsistanim.Persistence.BloodTestValues;

public sealed class BloodTestValueRepository(AppDbContext context):GenericRepository<BloodTestValue,int>(context), IBloodTestValueRepository
{
}
