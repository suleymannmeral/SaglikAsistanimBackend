

using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.Persistence.Users;

public sealed class UserHealthProfileRepository(AppDbContext context):GenericRepository<UserHealthProfile,string>(context), IUserHealthProfileRepository
{
}
