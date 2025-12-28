using SaglikAsistanim.Domain.Entities.Enums;

namespace SaglikAsistanim.Application.Features.Measurements.Queries.GetUserMesurementDetail;

public sealed record GetUserMeasurementDetailQueryResponse(
    MeasurementType Type,
    double Value1,
    double? Value2,
    string? Unit,
    DateTime MeasuredAt,
    string? Notes
    );
