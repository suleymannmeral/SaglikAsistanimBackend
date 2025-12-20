using SaglikAsistanim.Application.Features.Users;

namespace SaglikAsistanim.Application.Contracts.Identity;

public interface IUserService
{
    Task<ServiceResult<CreateUserResponse>> CreateUser(CreateUserRequest request);
    Task<bool>CheckIsUserExistByUserName(string userName);
    Task<ServiceResult<bool>> IsExistAsync(string userId);
    Task<ServiceResult> DeleteAsync(string userId);


}
