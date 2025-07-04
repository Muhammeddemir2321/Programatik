using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Features.TeacherFeature.Queries;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

public class CreateClassTeachingAssignmentCommand : IRequest<CreatedClassTeachingAssignmentDto>, ISecuredRequest
{
    public int WeeklyHourCount { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid ClassSectionId { get; set; }
    public bool IsOptional { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Create };
}