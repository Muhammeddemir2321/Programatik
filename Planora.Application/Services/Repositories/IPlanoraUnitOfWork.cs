using Core.Persistence.Repositories;

namespace Planora.Application.Services.Repositories;

public interface IPlanoraUnitOfWork : IUnitOfWork
{
    ISchoolRepository Schools { get; }
    ILectureRepository Lectures { get; }
    IGradeRepository Grades { get; }
    ITeacherRepository Teachers { get; }
    IClassSectionRepository ClassSections { get; }
    ISchoolScheduleSettingRepository SchoolScheduleSettings { get; }
    IClassTeachingAssignmentRepository ClassTeachingAssignments { get; }
    ILessonScheduleRepository LessonSchedules { get; }
    ILessonScheduleGroupRepository LessonScheduleGroups { get; }
    IUserRepository Users { get; }
    IIdentityRepository Identities { get; }
    IIdentityAuthorityRepository IdentityAuthorities { get; }
    IIdentityOperationClaimRepository IdentityOperationClaims { get; }
    IOperationClaimRepository OperationClaims { get; }
    IRefreshTokenRepository RefreshTokens { get; }
    IAuthorityOperationClaimRepository AuthorityOperationClaims { get; }
    IAuthorityRepository Authorities { get; }

}
