using SaglikAsistanim.Domain.Entities.Common;

namespace SaglikAsistanim.Domain.Entities;

public class UserHealthProfile:BaseEntity<int>
{
    public string ApplicationUserId { get; set; } = default!;
    public double Weight { get; set; }
    public double Height { get; set; }
    public string BloodType { get; set; } = default!;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

}
