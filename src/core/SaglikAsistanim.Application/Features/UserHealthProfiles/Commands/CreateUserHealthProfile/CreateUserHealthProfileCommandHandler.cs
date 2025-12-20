using MediatR;
using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;
using SaglikAsistanim.Application.Features.Users;
using SaglikAsistanim.Domain.Entities;
using System.Transactions;

public sealed class CreateUserHealthProfileCommandHandler(
    IUserService userService,
    IUserHealthProfileRepository userHealthProfileRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserHealthProfileCommand, ServiceResult<CreateUserHealthProfileResponse>>
{
    public async Task<ServiceResult<CreateUserHealthProfileResponse>> Handle(
        CreateUserHealthProfileCommand request,
        CancellationToken cancellationToken)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var userResult = await CreateUserAsync(request);
        if (!userResult.IsSuccess)
            return ServiceResult<CreateUserHealthProfileResponse>
                .Fail(userResult.ErrorMessage!);

        var profile = CreateUserHealthProfile(request, userResult.Data!.userId);

        await PersistProfileAsync(profile);

        scope.Complete();

        return ServiceResult<CreateUserHealthProfileResponse>
            .Success(new CreateUserHealthProfileResponse(profile.Id));
    }

    private async Task<ServiceResult<CreateUserResponse>> CreateUserAsync(
        CreateUserHealthProfileCommand request)
    {
        return await userService.CreateUser(request.userRequest);
    }

    private static UserHealthProfile CreateUserHealthProfile(
        CreateUserHealthProfileCommand request,
        string userId)
    {
        return new UserHealthProfile
        {
            ApplicationUserId = userId,
            Weight = request.Weight,
            Height = request.Height,
            BloodType = request.BloodType
        };
    }

    //Db'ye yansıt
    private async Task PersistProfileAsync(UserHealthProfile profile)
    {
        await userHealthProfileRepository.AddAsync(profile);
        await unitOfWork.SaveChangesAsync();
    }
}
