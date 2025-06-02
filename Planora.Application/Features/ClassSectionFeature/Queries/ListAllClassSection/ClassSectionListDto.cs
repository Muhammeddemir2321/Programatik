namespace Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;

public class ClassSectionListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
    public Guid GradeId { get; set; }
}
