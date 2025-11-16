namespace SaglikAsistanim.Application.Contracts.Identity;

public interface IUserService
{
    Task<ServiceResult<CreateUserResponse>> CreateUser(CreateUserRequest request);
    Task<bool>CheckIsUserExistByUserName(string userName);
}
