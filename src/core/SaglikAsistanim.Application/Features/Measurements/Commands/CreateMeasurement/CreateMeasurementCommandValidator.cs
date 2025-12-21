using FluentValidation;

namespace SaglikAsistanim.Application.Features.Measurements.Commands.CreateMeasurement;

using FluentValidation;

public sealed class CreateMeasurementCommandValidator
    : AbstractValidator<CreateMeasurementCommand>
{
    public CreateMeasurementCommandValidator()
    {

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Geçersiz ölçüm tipi.");

        RuleFor(x => x.Value1)
            .GreaterThan(0)
            .WithMessage("Ölçüm değeri 0'dan büyük olmalıdır.");

        RuleFor(x => x.Value2)
            .GreaterThan(0)
            .When(x => x.Value2.HasValue)
            .WithMessage("İkinci ölçüm değeri 0'dan büyük olmalıdır.");

        RuleFor(x => x.Unit)
            .NotEmpty()
            .When(x => !string.IsNullOrWhiteSpace(x.Unit))
            .WithMessage("Birim bilgisi boş olamaz.");

        RuleFor(x => x.MeasuredAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Ölçüm tarihi gelecekte olamaz.");

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .WithMessage("Notlar en fazla 500 karakter olabilir.");

    }
}