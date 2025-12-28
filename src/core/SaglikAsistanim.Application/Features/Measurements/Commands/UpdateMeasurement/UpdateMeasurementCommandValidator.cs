using FluentValidation;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.UpdateMeasurement;

using FluentValidation;

public sealed class UpdateMeasurementCommandValidator
    : AbstractValidator<UpdateMeasurementCommand>
{
    public UpdateMeasurementCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id 0'dan büyük olmalıdır.");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Geçersiz ölçüm tipi.");

        RuleFor(x => x.Value1)
            .NotNull()
            .WithMessage("Value1 zorunludur.")
            .GreaterThan(0)
            .WithMessage("Value1 0'dan büyük olmalıdır.");

        RuleFor(x => x.Value2)
            .GreaterThan(0)
            .When(x => x.Value2.HasValue)
            .WithMessage("Value2 0'dan büyük olmalıdır.");

        RuleFor(x => x.Unit)
            .MaximumLength(20)
            .When(x => !string.IsNullOrWhiteSpace(x.Unit))
            .WithMessage("Unit en fazla 20 karakter olabilir.");

        RuleFor(x => x.MeasuredAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Ölçüm tarihi gelecekte olamaz.");

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Notes))
            .WithMessage("Notlar en fazla 500 karakter olabilir.");
    }
}
