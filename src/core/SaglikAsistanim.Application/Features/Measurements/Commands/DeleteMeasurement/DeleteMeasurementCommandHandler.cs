using MediatR;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using System.Net;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.DeleteMeasurement;

public sealed class DeleteMeasurementCommandHandler(
    IMeasurementRepository measurementRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteMeasurementCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(
        DeleteMeasurementCommand request,
        CancellationToken cancellationToken)
    {
        var measurement = await GetMeasurementOrNullAsync(request.Id);

        if (measurement is null)
            return ServiceResult.Fail("Ölçüm kaydı bulunamadı.", HttpStatusCode.NotFound);

        await DeleteMeasurementAsync(measurement);

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    private async Task<Measurement?> GetMeasurementOrNullAsync(int id)
        => await measurementRepository.GetByIdAsync(id);

    private async Task DeleteMeasurementAsync(Measurement measurement)
    {
        measurementRepository.Delete(measurement);
        await unitOfWork.SaveChangesAsync();
    }
}
