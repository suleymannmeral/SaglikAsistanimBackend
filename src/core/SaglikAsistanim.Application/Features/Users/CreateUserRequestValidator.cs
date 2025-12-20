using FluentValidation;
using SaglikAsistanim.Application.Features.Users;

public sealed class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz.")
            .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Doğum tarihi gelecekte olamaz.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
            .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.")
            .MaximumLength(30).WithMessage("Kullanıcı adı en fazla 30 karakter olabilir.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email giriniz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz.");
    }
}
