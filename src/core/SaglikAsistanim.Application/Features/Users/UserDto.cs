
namespace SaglikAsistanim.Application.Features.Users;

public sealed record UserDto(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string UserName,
    string Phone,
    string Email
    );

