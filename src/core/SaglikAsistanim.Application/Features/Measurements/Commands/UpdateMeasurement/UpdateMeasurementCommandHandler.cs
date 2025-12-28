using MediatR;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.UpdateUserHealthProfile;
using SaglikAsistanim.Domain.Entities;
using System.Net;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.UpdateMeasurement;

public sealed class UpdateMeasurementCommandHandler(
    IMeasurementRepository measurementRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateMeasurementCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateMeasurementCommand request, CancellationToken cancellationToken)
    {
        var measurement = await GetMeasurementeOrFailAsync(request.Id);

        if(measurement is null)
            return ServiceResult.Fail("Ölçüm bulunamadı",System.Net.HttpStatusCode.NotFound);

        ApplyUpdates(measurement,request);

        await PersistAsync(measurement);

        return ServiceResult.Success(HttpStatusCode.OK);


    }
    private async Task<Measurement?> GetMeasurementeOrFailAsync(int id)
     => await measurementRepository.GetByIdAsync(id);

    private static void ApplyUpdates(
        Measurement measurement,
        UpdateMeasurementCommand request)
    {
        measurement.Value1 = request.Value1;
        measurement.Value2 = request.Value2;
        measurement.Unit = request.Unit;
        measurement.Notes = request.Notes;
        measurement.Type = request.Type;
        measurement.MeasuredAt = request.MeasuredAt;


    }

    private async Task PersistAsync(Measurement measurement)
    {
        measurementRepository.Update(measurement);
        await unitOfWork.SaveChangesAsync();
    }
}