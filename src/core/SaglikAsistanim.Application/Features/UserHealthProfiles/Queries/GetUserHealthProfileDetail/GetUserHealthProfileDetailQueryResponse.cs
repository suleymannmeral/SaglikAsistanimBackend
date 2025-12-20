


namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Queries.GetUserHealthProfileDetail;

public sealed  record GetUserHealthProfileDetailQueryResponse(double Weight,
    double Height,
    string BloodType,
    string UserName,
    string Email,
    string PhoneNumber,
    DateOnly DateOfBirth
    );
