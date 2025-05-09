using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureFeature.Commands;

public class DeleteLectureCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureClaimConstants.Delete };
    public class DeleteByIdLectureCommandHandler(
        ILectureRepository LectureRepository,
        LectureBusinessRules LectureBusinessRules)
        : IRequestHandler<DeleteLectureCommand, bool>
    {
        public async Task<bool> Handle(DeleteLectureCommand request, CancellationToken cancellationToken)
        {
            var Lecture = await LectureRepository.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await LectureBusinessRules.LectureShouldExistWhenRequested(Lecture);
            await LectureRepository.DeleteAsync(Lecture!, cancellationToken: cancellationToken);
            return true;

        }
    }
}
