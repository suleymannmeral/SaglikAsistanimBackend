using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.Persistence;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

}