namespace SaglikAsistanim.Application.Contracts.Identity;

public sealed record CreateUserRequest(string FirstName,
 string LastName,
 DateOnly DateOfBirth,
 string UserName,
 string Email,
 string Password,
 string PhoneNumber);

