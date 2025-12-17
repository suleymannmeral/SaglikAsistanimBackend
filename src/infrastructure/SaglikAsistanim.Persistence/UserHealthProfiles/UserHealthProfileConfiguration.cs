using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Persistence.Users;

public sealed class UserHealthProfileConfiguration : IEntityTypeConfiguration<UserHealthProfile>
{
    public void Configure(EntityTypeBuilder<UserHealthProfile> builder)
    {
       
    }
}
