using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureFeature.Commands;

public class CreateLectureCommand : IRequest<CreatedLectureDto>, ISecuredRequest
{
    public int FakeId { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureClaimConstants.Create };

    public class CreateLectureCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, LectureBusinessRules lectureBusinessRules)
        : IRequestHandler<CreateLectureCommand, CreatedLectureDto>
    {
        public async Task<CreatedLectureDto> Handle(CreateLectureCommand request, CancellationToken cancellationToken)
        {
            await lectureBusinessRules.LectureNameMustBeUniqeWhenCreateAsync(request.Name);
            var mappedLecture = mapper.Map<Lecture>(request);
            var createdLecture = await planoraUnitOfWork.Lectures.AddAsync(mappedLecture, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<CreatedLectureDto>(createdLecture);
        }
    }
}
