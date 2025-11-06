using SaglikAsistanim.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Domain.Entities;

public sealed class BloodTest:BaseEntity<int>
{
    public int UserHealthProfileId { get; set; }
    public string FilePath { get; set; } = string.Empty;   // PDF dosya yolu
    public string? AnalysisResult { get; set; }            // AI tarafından üretilen özet metin
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public ICollection<BloodTestValue> Values { get; set; } = new List<BloodTestValue>();

}
