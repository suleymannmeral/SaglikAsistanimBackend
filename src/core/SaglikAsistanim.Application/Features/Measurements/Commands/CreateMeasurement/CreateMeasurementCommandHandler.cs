using MediatR;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.CreateMeasurement;

public sealed class CreateMeasurementCommandHandler(IMeasurementRepository measurementRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMeasurementCommand, ServiceResult<CreateMeasurementCommandResponse>>

{
    public async Task<ServiceResult<CreateMeasurementCommandResponse>> Handle(CreateMeasurementCommand request, CancellationToken cancellationToken)
    {
        var measurement = CreateMeasurement(request);
        await PersistAsync(measurement);

        return ServiceResult<CreateMeasurementCommandResponse>
           .Success(new CreateMeasurementCommandResponse(measurement.Id));

    }

    private static Measurement CreateMeasurement(
    CreateMeasurementCommand request)
    {
        return new Measurement
        {
          UserHealthProfileId=request.UserHealthProfileId,
          Type=request.Type,
          Value1=request.Value1,
          Value2=request.Value2,
          Unit=request.Unit,
          MeasuredAt=request.MeasuredAt,
          Notes=request.Notes
        };
    }

    //Db'ye yansıt
    private async Task PersistAsync(Measurement measurement)
    {
        await measurementRepository.AddAsync(measurement);
        await unitOfWork.SaveChangesAsync();
    }
}
