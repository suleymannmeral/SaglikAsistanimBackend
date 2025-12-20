using MediatR;
using SaglikAsistanim.Application.Features.Users;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.UpdateUserHealthProfile;

public sealed record UpdateUserHealthProfileCommand(string Id,
    double Weight,
    double Height,
    string BloodType,
    UpdateUserRequest updateUserRequest
    ) : IRequest<ServiceResult>;


