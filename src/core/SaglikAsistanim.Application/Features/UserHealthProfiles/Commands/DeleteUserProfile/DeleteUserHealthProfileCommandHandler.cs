using MediatR;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Application.Contracts.Persistence;
using System.Net;
using System.Transactions;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.DeleteUserProfile;

public sealed class DeleteUserHealthProfileCommandHandler(
    IUserService userService,
    IUserHealthProfileRepository userHealthRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<
    DeleteUserHealthProfileCommand,
    ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteUserHealthProfileCommand request, CancellationToken cancellationToken)
    {
        var userHealthProfile = await userHealthRepository.GetByIdAsync(request.Id);

        if (userHealthProfile is null)
            return ServiceResult.Fail("Profil bulunamadı.", HttpStatusCode.NotFound);

        var userExist= await userService.IsExistAsync(request.Id);

        if(!userExist.Data)
            return ServiceResult.Fail("Kullanıcı Bulunamadı",HttpStatusCode.NotFound);


        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await userService.DeleteAsync(userHealthProfile.ApplicationUserId);  // UserManager işlemi
            userHealthRepository.Delete(userHealthProfile);
            await unitOfWork.SaveChangesAsync();          // Repository işlemi

            scope.Complete(); // Her ikisi de başarılıysa commit
        }

        return ServiceResult.Success(HttpStatusCode.NoContent);

    }
}
