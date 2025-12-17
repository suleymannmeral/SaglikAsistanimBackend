using FluentValidation;

namespace SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;

public sealed class CreateUserHealthProfileCommandValidator
    : AbstractValidator<CreateUserHealthProfileCommand>
{
    public CreateUserHealthProfileCommandValidator()
    {
        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Kilo 0'dan büyük olmalıdır.")
            .LessThan(500).WithMessage("Kilo maksimum 500 olabilir.");

        RuleFor(x => x.Height)
            .GreaterThan(0).WithMessage("Boy 0'dan büyük olmalıdır.")
            .LessThan(300).WithMessage("Boy maksimum 300 cm olabilir.");

        RuleFor(x => x.BloodType)
            .NotEmpty().WithMessage("Kan grubu boş olamaz.")
            .Matches("^(A|B|AB|O)[+-]$").WithMessage("Geçerli bir kan grubu giriniz (Ör: A+, 0-, AB+).");

      
        // Nested User validator
        RuleFor(x => x.userRequest)
            .NotNull().WithMessage("Kullanıcı bilgileri zorunludur.")
            .SetValidator(new CreateUserRequestValidator());
    }
}
