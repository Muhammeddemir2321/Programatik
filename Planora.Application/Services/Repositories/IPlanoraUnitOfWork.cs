using Core.Persistence.Repositories;

namespace Planora.Application.Services.Repositories;

public interface IPlanoraUnitOfWork : IUnitOfWork
{
    IAuthorityOperationClaimRepository AuthorityOperationClaims { get; }
    IAuthorityRepository Authorities { get; }
    IClassCourseAssignmentRepository ClassCourseAssignments { get; }
    IClassSectionRepository ClassSections { get; }
    ICourseRepository Courses { get; }
    IGradeRepository Grades { get; }
    IIdentityAuthorityRepository IdentityAuthorities { get; }
    IIdentityOperationClaimRepository IdentityOperationClaims { get; }
    IIdentityRepository Identities { get; }
    ILectureRepository Lectures { get; }
    IOperationClaimRepository OperationClaims { get; }
    IRefreshTokenRepository RefreshTokens { get; }
    ISchoolRepository Schools { get; }
    ITeacherRepository Teachers { get; }
    IUserRepository Users { get; }

}
