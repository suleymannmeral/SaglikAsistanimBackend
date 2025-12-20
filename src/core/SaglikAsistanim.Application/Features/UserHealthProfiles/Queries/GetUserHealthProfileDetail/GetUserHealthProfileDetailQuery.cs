using MediatR;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Queries.GetUserHealthProfileDetail;

public sealed record GetUserHealthProfileDetailQuery(string Id)
    : IRequest<ServiceResult<GetUserHealthProfileDetailQueryResponse>>;
