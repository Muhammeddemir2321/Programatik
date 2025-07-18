﻿using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureFeature.Commands;

public class UpdateLectureCommand : IRequest<UpdatedLectureDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureClaimConstants.Update };



    public class UpdateLectureCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        IMapper mapper,
        LectureBusinessRules lectureBusinessRules)
        : IRequestHandler<UpdateLectureCommand, UpdatedLectureDto>
    {
        public async Task<UpdatedLectureDto> Handle(UpdateLectureCommand request, CancellationToken cancellationToken)
        {
            await lectureBusinessRules.LectureNameMustBeUniqueWhenUpdateAsync(request.Id, request.Name);
            var mappedLecture = mapper.Map<Lecture>(request);
            var updatedLecture = await planoraUnitOfWork.Lectures.UpdateAsync(mappedLecture, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<UpdatedLectureDto>(updatedLecture);
        }
    }

}
