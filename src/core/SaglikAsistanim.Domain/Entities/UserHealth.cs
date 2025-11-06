using SaglikAsistanim.Domain.Entities.Common;


namespace SaglikAsistanim.Domain.Entities;

public class UserHealth:BaseEntity<int>
{
    public string ApplicationUserId { get; set; } = default!;
    public double Weight { get; set; }
    public double Height { get; set; }

}
