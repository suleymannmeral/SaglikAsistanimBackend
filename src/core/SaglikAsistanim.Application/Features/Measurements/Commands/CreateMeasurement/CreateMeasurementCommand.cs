using MediatR;
using SaglikAsistanim.Domain.Entities.Enums;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.CreateMeasurement;

public sealed record CreateMeasurementCommand(string UserHealthProfileId,
    MeasurementType Type,
    double Value1,
    double? Value2,
    string? Unit,
    DateTime MeasuredAt,
    string? Notes
    ) : IRequest<ServiceResult<CreateMeasurementCommandResponse>>;

