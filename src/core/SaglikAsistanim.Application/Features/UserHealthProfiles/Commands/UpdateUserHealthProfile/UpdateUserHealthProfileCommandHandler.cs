using MediatR;
using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.UpdateUserHealthProfile;
using SaglikAsistanim.Domain.Entities;
using System.Net;

public sealed class UpdateUserHealthProfileCommandHandler(
    IUserHealthProfileRepository userHealthProfileRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateUserHealthProfileCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(
        UpdateUserHealthProfileCommand request,
        CancellationToken cancellationToken)
    {
        var profile = await GetProfileOrFailAsync(request.Id);
        if (profile is null)
            return ServiceResult.Fail("Profil bulunamadı.", HttpStatusCode.NotFound);

        ApplyUpdates(profile, request);

        await PersistAsync(profile);

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    private async Task<UserHealthProfile?> GetProfileOrFailAsync(string id)
        => await userHealthProfileRepository.GetByIdAsync(id);

    private static void ApplyUpdates(
        UserHealthProfile profile,
        UpdateUserHealthProfileCommand request)
    {
        profile.Weight = request.Weight;
        profile.Height = request.Height;
        profile.BloodType = request.BloodType;
    }

    private async Task PersistAsync(UserHealthProfile profile)
    {
        userHealthProfileRepository.Update(profile);
        await unitOfWork.SaveChangesAsync();
    }
}
