using FluentValidation;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.DeleteUserProfile;

public sealed class DeleteUserHealthProfileCommandValidator 
    :AbstractValidator<DeleteUserHealthProfileCommand>
{
    public DeleteUserHealthProfileCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty();

    }
}
