using MediatR;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Application.Features.Users;
using SaglikAsistanim.Domain.Entities;
using System.Net;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Queries.GetUserHealthProfileDetail;

public sealed class GetUserHealthProfileDetailQueryHandler(
    IUserHealthProfileRepository userHealthProfileRepository,
    IUserService userService)
    : IRequestHandler<GetUserHealthProfileDetailQuery, ServiceResult<GetUserHealthProfileDetailQueryResponse>>
{
    public async Task<ServiceResult<GetUserHealthProfileDetailQueryResponse>> Handle(
          GetUserHealthProfileDetailQuery request,
          CancellationToken cancellationToken)
    {
        var profile = await GetProfileAsync(request.Id);
        if (profile is null)
            return ServiceResult<GetUserHealthProfileDetailQueryResponse>.Fail("Profil Bulunamadı");

        var userResult = await GetUserAsync(profile.ApplicationUserId);
        if (!userResult.IsSuccess)
            return ServiceResult<GetUserHealthProfileDetailQueryResponse>.Fail("Kullanıcı Bulunamadı");

        var response = CreateResponse(profile, userResult.Data!);

        return ServiceResult<GetUserHealthProfileDetailQueryResponse>.Success(response);
    }


    private async Task<UserHealthProfile?> GetProfileAsync(string profileId)
        =>await  userHealthProfileRepository.GetByIdAsync(profileId);

    private async Task<ServiceResult<UserDto>> GetUserAsync(string userId)
        => await userService.GetUserByIdAsync(userId);

    private static GetUserHealthProfileDetailQueryResponse CreateResponse(
        UserHealthProfile profile,
        UserDto user)
    {
        return new GetUserHealthProfileDetailQueryResponse(
            Weight: profile.Weight,
            Height: profile.Height,
            BloodType: profile.BloodType,
            UserName: user.FirstName,
            Email: user.Email,
            PhoneNumber: user.Phone,
            DateOfBirth: user.DateOfBirth
        );
    }

 
  
}
