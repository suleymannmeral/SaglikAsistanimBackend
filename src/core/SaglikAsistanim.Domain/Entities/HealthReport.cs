using SaglikAsistanim.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Domain.Entities;

public sealed class HealthReport:BaseEntity<int>
{
    public int UserId { get; set; }
    public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    public string Summary { get; set; } = string.Empty; // AI tarafından oluşturulmuş metin
    public string? Recommendations { get; set; }        // Öneriler (örneğin: “Şekerini takip et”)
    public double? HealthScore { get; set; }            // 0-100 arası sağlık puanı
}
