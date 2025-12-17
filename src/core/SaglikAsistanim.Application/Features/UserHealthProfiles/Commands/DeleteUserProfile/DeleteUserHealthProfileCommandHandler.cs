using MediatR;
using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.DeleteUserProfile;
using SaglikAsistanim.Domain.Entities;
using System.Net;
using System.Transactions;

public sealed class DeleteUserHealthProfileCommandHandler(
    IUserHealthProfileRepository userHealthRepository,
    IUserService userService,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteUserHealthProfileCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(
        DeleteUserHealthProfileCommand request,
        CancellationToken cancellationToken)
    {
        var profile = await GetProfileOrNullAsync(request.Id);
        if (profile is null)
            return ServiceResult.Fail("Profil bulunamadı.", HttpStatusCode.NotFound);

        var userExistsResult = await CheckUserExistsAsync(profile.ApplicationUserId);
        if (!userExistsResult)
            return ServiceResult.Fail("Kullanıcı bulunamadı.", HttpStatusCode.NotFound);

        await DeleteUserAndProfileAsync(profile);

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    private async Task<UserHealthProfile?> GetProfileOrNullAsync(string id)
        => await userHealthRepository.GetByIdAsync(id);
    private async Task<bool> CheckUserExistsAsync(string applicationUserId)
    {
        var result = await userService.IsExistAsync(applicationUserId);
        return result.Data;
    }
    private async Task DeleteUserAndProfileAsync(UserHealthProfile profile)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        await userService.DeleteAsync(profile.ApplicationUserId);
        userHealthRepository.Delete(profile);
        await unitOfWork.SaveChangesAsync();

        scope.Complete();
    }
}
