using MediatR;
using SaglikAsistanim.Domain.Entities.Enums;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.UpdateMeasurement;

public sealed record UpdateMeasurementCommand(int Id,
    MeasurementType Type,
    double Value1,
    double? Value2,
    string? Unit,
    DateTime MeasuredAt,
    string? Notes) : IRequest<ServiceResult>;
