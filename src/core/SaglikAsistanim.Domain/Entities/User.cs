using SaglikAsistanim.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Domain.Entities;

public class User:BaseEntity<int>
{
    public string ApplicationUserId { get; set; } = default!;
    public double Weight { get; set; }
    public double Height { get; set; }

}
