using MediatR;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetAllConstraints;

public class GetAllConstraintsQuery: IRequest<List<ConstraintDto>>
{
}
