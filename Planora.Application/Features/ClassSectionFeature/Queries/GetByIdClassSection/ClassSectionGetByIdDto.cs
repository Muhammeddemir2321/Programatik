namespace Planora.Application.Features.ClassSectionFeature.Queries.GetByIdClassSection;

public class ClassSectionGetByIdDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
    public Guid GradeId { get; set; }
}
