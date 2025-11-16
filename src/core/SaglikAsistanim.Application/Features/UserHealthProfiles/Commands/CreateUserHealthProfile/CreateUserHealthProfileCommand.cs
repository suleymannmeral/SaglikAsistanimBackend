using MediatR;
using SaglikAsistanim.Application.Contracts.Identity;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;

public sealed record CreateUserHealthProfileCommand(double Weight,
    double Height,
    string BloodType,
    DateTime LastUpdated,
    CreateUserRequest userRequest):IRequest<ServiceResult<CreateUserHealthProfileResponse>>;

