using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolFeature.Commands;

public class DeleteSchoolCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { SchoolClaimConstants.Delete };
    public class DeleteByIdSchoolCommandHandler(
        ISchoolRepository schoolRepository,
        SchoolBusinessRules schoolBusinessRules)
        : IRequestHandler<DeleteSchoolCommand, bool>
    {
        public async Task<bool> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await schoolRepository.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await schoolBusinessRules.SchoolShouldExistWhenRequested(school);
            await schoolRepository.DeleteAsync(school!, cancellationToken: cancellationToken);
            return true;

        }
    }
}
