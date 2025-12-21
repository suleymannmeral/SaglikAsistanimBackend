using MediatR;

namespace SaglikAsistanim.Application.Features.BloodTests.Commands.CreateBloodTest;

public sealed record CreateBloodTestCommand(string UserHealthProfileId,
    string FilePath,
    string AnalysisResult,
    DateTime UploadedAt
    ) : IRequest<ServiceResult<CreateBloodTestCommandResponse>>;

