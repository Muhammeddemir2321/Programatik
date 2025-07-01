using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;

public class ClassTeachingAssignmentBusinessRules(IClassTeachingAssignmentRepository ClassTeachingAssignmentRepository)
    :BaseBusinessRules
{
}
