using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LectureFeature.Commands;

public class CreateLectureCommand : IRequest<CreatedLectureDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new string[] { LectureClaimConstants.Create };

    public class CreateLectureCommandHandler(
        ILectureRepository LectureRepository, IMapper mapper, LectureBusinessRules LectureBusinessRules)
        : IRequestHandler<CreateLectureCommand, CreatedLectureDto>
    {
        public async Task<CreatedLectureDto> Handle(CreateLectureCommand request, CancellationToken cancellationToken)
        {
            await LectureBusinessRules.LectureNameMustNotBeEmpty(request.Name);
            await LectureBusinessRules.LectureNameMustBeUniqeWhenCreate(request.Name);
            var mappedLecture = mapper.Map<Lecture>(request);
            var createdLecture = await LectureRepository.AddAsync(mappedLecture, cancellationToken: cancellationToken);
            return mapper.Map<CreatedLectureDto>(createdLecture);
        }
    }
}
