using MediatR;
using SaglikAsistanim.Application.Contracts.Persistence;

namespace SaglikAsistanim.Application.Features.BloodTests.Commands.CreateBloodTest;

public sealed class CreateBloodTestCommandHandler(IBloodTestRepository bloodTestRepository) 
    : IRequestHandler<CreateBloodTestCommand, ServiceResult<CreateBloodTestCommandResponse>>
{
    public Task<ServiceResult<CreateBloodTestCommandResponse>> Handle(CreateBloodTestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
