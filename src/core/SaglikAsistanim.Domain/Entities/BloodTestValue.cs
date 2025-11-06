using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Domain.Entities;

public sealed class BloodTestValue
{
    public int BloodTestId { get; set; }
    public string TestName { get; set; } = string.Empty;   // Örn: “Glukoz”
    public double Value { get; set; }                      // Örn: 110
    public string Unit { get; set; } = string.Empty;      
    public string? ReferenceRange { get; set; }          
    public string? Status { get; set; }                   
    public BloodTest BloodTest { get; set; } = null!;
}
