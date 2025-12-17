using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Identity;
using SaglikAsistanim.Identity.Models;
using System.Net;

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
        
        var existByEmail = await userManager.FindByEmailAsync(request.Email);
        if (existByEmail != null)
            return ServiceResult<CreateUserResponse>.Fail("Email Mevcut!");

        var existByUserName = await userManager.FindByNameAsync(request.UserName);
        if (existByUserName != null)
            return ServiceResult<CreateUserResponse>.Fail("Kullanıcı adı mevcut!");

        var existPhoneNumber = await CheckIsPhoneNumberExist(request.PhoneNumber);
        if(existPhoneNumber.Data)
            return ServiceResult<CreateUserResponse>.Fail("Bu telefon numarası sisteme kayıtlı!");



        // create applicationUser instance
        var user = new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        // 3) create user
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            
            var errors = result.Errors.Select(x => x.Description).ToList();
            return ServiceResult<CreateUserResponse>.Fail(errors);
        }

        // 4) Response oluştur
        var response = new CreateUserResponse(
            user.Id

        );

        return ServiceResult<CreateUserResponse>.Success(response);
    }

    public async Task<ServiceResult<bool>> IsExistAsync(string userId)
    {
        var response= await userManager.Users.AnyAsync(u => u.Id==userId);

        return ServiceResult<bool>.Success(response);

    }


    public async Task<ServiceResult> DeleteAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user is null)
            return ServiceResult.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);

        await userManager.DeleteAsync(user);

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}



    
