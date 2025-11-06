using SaglikAsistanim.Domain.Entities.Common;
using SaglikAsistanim.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Domain.Entities;

public sealed class Measurement:BaseEntity<int>
{
    public int UserId { get; set; }
    public MeasurementType Type { get; set; }  // Enum: BloodPressure, Glucose, 
    public double Value1 { get; set; }         
    public double? Value2 { get; set; }        
    public string? Unit { get; set; }          // mg/dL, mmHg vb.
    public DateTime MeasuredAt { get; set; }
    public string? Notes { get; set; }
}
