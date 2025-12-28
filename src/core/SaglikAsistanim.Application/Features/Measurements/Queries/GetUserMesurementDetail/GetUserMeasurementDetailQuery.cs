using MediatR;

namespace SaglikAsistanim.Application.Features.Measurements.Queries.GetUserMesurementDetail;

public sealed record GetUserMeasurementDetailQuery(int Id) : IRequest<ServiceResult<GetUserMeasurementDetailQueryResponse>>;
