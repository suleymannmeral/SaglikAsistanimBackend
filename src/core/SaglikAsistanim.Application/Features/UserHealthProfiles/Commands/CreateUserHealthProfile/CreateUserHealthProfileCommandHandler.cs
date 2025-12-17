using MediatR;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using System.Transactions;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;

public sealed class CreateUserHealthProfileCommandHandler
    : IRequestHandler<CreateUserHealthProfileCommand, ServiceResult<CreateUserHealthProfileResponse>>
{
    private readonly IUserService _userService;
    private readonly IUserHealthProfileRepository _userHealthProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHealthProfileCommandHandler(
        IUserService userService,
        IUserHealthProfileRepository userHealthProfileRepository,
        IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _userHealthProfileRepository = userHealthProfileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<CreateUserHealthProfileResponse>> Handle(
        CreateUserHealthProfileCommand request,
        CancellationToken cancellationToken)
    {
        // TransactionScope kullanıyoruz, async akış için Enabled
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        try
        {
            // User oluştur 
            var userResult = await _userService.CreateUser(request.userRequest);
            if (!userResult.IsSuccess)
                return ServiceResult<CreateUserHealthProfileResponse>.Fail(userResult.ErrorMessage!);

            string userId = userResult.Data!.userId;

            // create UserHealthProfile instance
            var userHealthProfile = new UserHealthProfile
            {
                ApplicationUserId = userId,
                Weight = request.Weight,
                Height = request.Height,
                BloodType = request.BloodType,
            };

            await _userHealthProfileRepository.AddAsync(userHealthProfile);
            await _unitOfWork.SaveChangesAsync();

            //Tüm işlemler başarılı → commit
            scope.Complete();

            return ServiceResult<CreateUserHealthProfileResponse>.Success(
                new CreateUserHealthProfileResponse(userHealthProfile.Id));
        }
        catch (Exception ex)
        {
            //scope.Dispose()  otomatik
            return ServiceResult<CreateUserHealthProfileResponse>.Fail("İşlem başarısız: " + ex.Message);
        }
    }
}
