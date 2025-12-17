using SaglikAsistanim.Domain.Entities.Common;

namespace SaglikAsistanim.Domain.Entities;

public class UserHealthProfile:BaseEntity<string>
{
    public UserHealthProfile()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string ApplicationUserId { get; set; } = default!;
    public double Weight { get; set; }
    public double Height { get; set; }
    public string BloodType { get; set; } = default!;

}
