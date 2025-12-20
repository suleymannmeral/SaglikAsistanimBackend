using SaglikAsistanim.Application.Features.Users;

namespace SaglikAsistanim.API.Contracts.Requests;

public sealed record UpdateUserHealthProfileRequest(
    double Weight,
    double Height,
    string BloodType,
    UpdateUserRequest UpdateUserRequest
);
