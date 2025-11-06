using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.Users;

public sealed class UserHealthConfiguration : IEntityTypeConfiguration<UserHealth>
{
    public void Configure(EntityTypeBuilder<UserHealth> builder)
    {
        throw new NotImplementedException();
    }
}
