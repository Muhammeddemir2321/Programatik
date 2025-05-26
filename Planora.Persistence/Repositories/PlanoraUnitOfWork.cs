using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class PlanoraUnitOfWork : UnitOfWork<PlanoraDbContext>, IPlanoraUnitOfWork
{
    public IAuthorityOperationClaimRepository AuthorityOperationClaims { get; }
    public IAuthorityRepository Authorities { get; }
    public IClassCourseAssignmentRepository ClassCourseAssignments { get; }
    public IClassSectionRepository ClassSections { get; }
    public ICourseRepository Courses { get; }
    public IGradeRepository Grades { get; }
    public IIdentityAuthorityRepository IdentityAuthorities { get; }
    public IIdentityOperationClaimRepository IdentityOperationClaims { get; }
    public IIdentityRepository Identities { get; }
    public ILectureRepository Lectures { get; }
    public IOperationClaimRepository OperationClaims { get; }
    public IRefreshTokenRepository RefreshTokens { get; }
    public ISchoolRepository Schools { get; }
    public ITeacherRepository Teachers { get; }
    public IUserRepository Users { get; }
    public PlanoraUnitOfWork(PlanoraDbContext context,
        IAuthorityOperationClaimRepository authorityOperationClaims,
        IAuthorityRepository authorities,
        IClassCourseAssignmentRepository classCourseAssignments,
        IClassSectionRepository classSections,
        ICourseRepository courses,
        IGradeRepository grades,
        IIdentityAuthorityRepository identityAuthorities,
        IIdentityOperationClaimRepository identityOperationClaims,
        IIdentityRepository identities,
        ILectureRepository lectures,
        IOperationClaimRepository operationClaims,
        IRefreshTokenRepository refreshTokens,
        ISchoolRepository schools,
        ITeacherRepository teachers,
        IUserRepository users

    ) : base(context)
    {
        AuthorityOperationClaims = authorityOperationClaims;
        Authorities = authorities;
        ClassCourseAssignments = classCourseAssignments;
        ClassSections = classSections;
        Courses = courses;
        Grades = grades;
        IdentityAuthorities = identityAuthorities;
        IdentityOperationClaims = identityOperationClaims;
        Identities = identities;
        Lectures = lectures;
        OperationClaims = operationClaims;
        RefreshTokens = refreshTokens;
        Schools = schools;
        Teachers = teachers;
        Users = users;
    }
}
