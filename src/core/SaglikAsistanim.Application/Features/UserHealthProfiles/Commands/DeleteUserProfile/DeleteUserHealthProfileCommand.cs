using MediatR;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.DeleteUserProfile;

public sealed record DeleteUserHealthProfileCommand(string Id) : IRequest<ServiceResult>;
