using SaglikAsistanim.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Domain.Entities;

public sealed class Medication:BaseEntity<int>
{
    public int UserHealthProfileId { get; set; }
    public string DrugName { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty; // Örn: “Günde 2 defa”
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive {  get; set; }

}
