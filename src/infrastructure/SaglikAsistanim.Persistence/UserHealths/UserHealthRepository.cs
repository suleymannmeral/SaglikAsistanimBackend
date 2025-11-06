

using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.Persistence.Users;

public sealed class UserHealthRepository(AppDbContext context):GenericRepository<UserHealth,int>(context), IUserHealthRepository
{
}
