using MediatR;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;

namespace SaglikAsistanim.Application.Features.Measurements.Queries.GetUserMesurementDetail;

public sealed class GetUserMeasurementDetailQueryHandler(IMeasurementRepository measurementRepository)
    : IRequestHandler<GetUserMeasurementDetailQuery, ServiceResult<GetUserMeasurementDetailQueryResponse>>
{
    public async Task<ServiceResult<GetUserMeasurementDetailQueryResponse>> Handle(GetUserMeasurementDetailQuery request, CancellationToken cancellationToken)
    {
        var measurement= await GetMeasurementeOrFailAsync(request.Id);

        if(measurement is null)
            return ServiceResult<GetUserMeasurementDetailQueryResponse>.Fail("Ölçüm Bulunamadı",System.Net.HttpStatusCode.NotFound);

        var response=  CreateResponse(measurement);
         
        return ServiceResult<GetUserMeasurementDetailQueryResponse>.Success(response);

    }

    private async Task<Measurement?> GetMeasurementeOrFailAsync(int id)
    => await measurementRepository.GetByIdAsync(id);


    private static GetUserMeasurementDetailQueryResponse CreateResponse(
    Measurement measurement)
    {
        return new GetUserMeasurementDetailQueryResponse(
          Type: measurement.Type,
            Value1: measurement.Value1,
            Value2: measurement.Value2,
            Unit: measurement.Unit,
            MeasuredAt: measurement.MeasuredAt,
            Notes: measurement.Notes
        );
    }

}
