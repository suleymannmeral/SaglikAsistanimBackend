namespace SaglikAsistanim.Application.Features.Users;

public sealed record UpdateUserRequest(string FirstName,
string LastName,
DateOnly DateOfBirth,
string UserName,
string Email,
string Password,
string PhoneNumber);
