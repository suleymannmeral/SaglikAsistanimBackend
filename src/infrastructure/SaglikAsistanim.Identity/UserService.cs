using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Identity.Models;

namespace SaglikAsistanim.Identity;

public sealed class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    public async Task<bool> CheckIsUserExistByUserName(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);

        if (user is null)
            return false;

        return true;
    }
    public async Task<ServiceResult<bool>> CheckIsPhoneNumberExist(string phoneNumber)
    {
        var exists = await userManager.Users
            .AnyAsync(x => x.PhoneNumber == phoneNumber);

        return ServiceResult<bool>.Success(exists);
    }


    public async Task<ServiceResult<CreateUserResponse>> CreateUser(CreateUserRequest request)
    {
        // 1) Email veya UserName daha önce var mı kontrol et
        var existByEmail = await userManager.FindByEmailAsync(request.Email);
        if (existByEmail != null)
            return ServiceResult<CreateUserResponse>.Fail("Email Mevcut");

        var existByUserName = await userManager.FindByNameAsync(request.UserName);
        if (existByUserName != null)
            return ServiceResult<CreateUserResponse>.Fail("Kullanıcı adı mevcut");

        var existPhoneNumber = await CheckIsPhoneNumberExist(request.PhoneNumber);

        if(existPhoneNumber.Data)
            return ServiceResult<CreateUserResponse>.Fail("Teelfon sisteme kayıltı");



        // 2) ApplicationUser nesnesini doldur
        var user = new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        // 3) UserManager ile kullanıcı oluştur
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            // Identity hatalarını ServiceResult formatında geri döndür
            var errors = result.Errors.Select(x => x.Description).ToList();
            return ServiceResult<CreateUserResponse>.Fail(errors);
        }

        // 4) Response oluştur
        var response = new CreateUserResponse(
            user.Id

        );

        return ServiceResult<CreateUserResponse>.Success(response);
    }
}
