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
    public class DeleteSchoolCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        SchoolBusinessRules schoolBusinessRules)
        : IRequestHandler<DeleteSchoolCommand, bool>
    {
        public async Task<bool> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await planoraUnitOfWork.Schools.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await schoolBusinessRules.SchoolShouldExistWhenRequestedAsync(school);
            await planoraUnitOfWork.Schools.DeleteAsync(school!, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return true;

        }
    }
}
