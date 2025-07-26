using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class PlanoraUnitOfWork : UnitOfWork<PlanoraDbContext>, IPlanoraUnitOfWork
{
    public ISchoolRepository Schools { get; }
    public ILectureRepository Lectures { get; }
    public IGradeRepository Grades { get; }
    public ITeacherRepository Teachers { get; }
    public ITeacherUnavailableRepository TeacherUnavailables { get; }
    public IClassSectionRepository ClassSections { get; }
    public ISchoolScheduleSettingRepository SchoolScheduleSettings { get; }
    public ILectureDistributionOptionRepository LectureDistributionOptions { get; }
    public IClassTeachingAssignmentRepository ClassTeachingAssignments { get; }
    public ILessonScheduleRepository LessonSchedules { get; }
    public ILessonScheduleGroupRepository LessonScheduleGroups { get; }
    public IUserRepository Users { get; }
    public IIdentityRepository Identities { get; }
    public IAuthorityOperationClaimRepository AuthorityOperationClaims { get; }
    public IAuthorityRepository Authorities { get; }
    public IIdentityAuthorityRepository IdentityAuthorities { get; }
    public IIdentityOperationClaimRepository IdentityOperationClaims { get; }
    public IOperationClaimRepository OperationClaims { get; }
    public IRefreshTokenRepository RefreshTokens { get; }
    public PlanoraUnitOfWork(PlanoraDbContext context,
        IAuthorityOperationClaimRepository authorityOperationClaims,
        IAuthorityRepository authorities,
        ILessonScheduleRepository lessonSchedules,
        ILessonScheduleGroupRepository lessonScheduleGroups,
        IClassSectionRepository classSections,
        IClassTeachingAssignmentRepository classTeachingAssignments,
        ISchoolScheduleSettingRepository schoolScheduleSettings,
        ILectureDistributionOptionRepository lectureDistributionOptions,
        IGradeRepository grades,
        IIdentityAuthorityRepository identityAuthorities,
        IIdentityOperationClaimRepository identityOperationClaims,
        IIdentityRepository identities,
        ILectureRepository lectures,
        IOperationClaimRepository operationClaims,
        IRefreshTokenRepository refreshTokens,
        ISchoolRepository schools,
        ITeacherRepository teachers,
        ITeacherUnavailableRepository teacherUnavailables,
        IUserRepository users

    ) : base(context)
    {
        AuthorityOperationClaims = authorityOperationClaims;
        Authorities = authorities;
        LessonSchedules = lessonSchedules;
        LessonScheduleGroups = lessonScheduleGroups;
        ClassSections = classSections;
        ClassTeachingAssignments = classTeachingAssignments;
        SchoolScheduleSettings = schoolScheduleSettings;
        LectureDistributionOptions = lectureDistributionOptions;
        Grades = grades;
        IdentityAuthorities = identityAuthorities;
        IdentityOperationClaims = identityOperationClaims;
        Identities = identities;
        Lectures = lectures;
        OperationClaims = operationClaims;
        RefreshTokens = refreshTokens;
        Schools = schools;
        Teachers = teachers;
        TeacherUnavailables = teacherUnavailables;
        Users = users;
    }
}
