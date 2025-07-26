using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetAllConstraints;

public class GetAllConstraintsQueryHandler : IRequestHandler<GetAllConstraintsQuery, List<ConstraintDto>>
{
    public Task<List<ConstraintDto>> Handle(GetAllConstraintsQuery request, CancellationToken cancellationToken)
    {
        var constraints = new List<ConstraintDto>
        {
            new() { Key = ConstraintNamesConstant.TeacherDailyLessonLimitConstraint, Display = "Öğretmen Günlük Ders Limiti" },
            new() { Key = ConstraintNamesConstant.ConsecutiveLessonConstraint, Display = "Arka Arkaya Ders Limiti" },
            //new() { Key = ConstraintNamesConstant.TeacherUnavailableConstraint, Display = "Öğretmen Müsait Değil" },
            //new() { Key = ConstraintNamesConstant.TeacherConflictConstraint, Display = "Öğretmen Çakışma Kontrolü" },
            //new() { Key = ConstraintNamesConstant.MaxSameDayLessonConstraint, Display = "Aynı Gün Ders Tekrarı Limiti" }
        };

        return Task.FromResult(constraints);
    }
}
