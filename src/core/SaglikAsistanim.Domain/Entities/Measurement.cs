using SaglikAsistanim.Domain.Entities.Common;
using SaglikAsistanim.Domain.Entities.Enums;


namespace SaglikAsistanim.Domain.Entities;

public sealed class Measurement:BaseEntity<int>
{
    public string UserHealthProfileId { get; set; } = null!;
    public MeasurementType Type { get; set; }  // Enum: BloodPressure, Glucose, 
    public double Value1 { get; set; }         
    public double? Value2 { get; set; }        
    public string? Unit { get; set; }          // mg/dL, mmHg vb.
    public DateTime MeasuredAt { get; set; }
    public string? Notes { get; set; }
}
