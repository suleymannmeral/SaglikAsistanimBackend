using SaglikAsistanim.Domain.Entities.Enums;

namespace SaglikAsistanim.API.Contracts.Requests;

public sealed record UpdateMeasurementRequest(MeasurementType Type,
    double Value1,
    double? Value2,
    string? Unit,
    DateTime MeasuredAt,
    string? Notes);
