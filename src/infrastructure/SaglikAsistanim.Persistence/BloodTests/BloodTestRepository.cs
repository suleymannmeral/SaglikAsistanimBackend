using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.Persistence.BloodTests;

public sealed class BloodTestRepository(AppDbContext context):GenericRepository<BloodTest,int>(context), IBloodTestRepository
{
}
