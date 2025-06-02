namespace Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;

public class CreatedClassSectionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
    public Guid GradeId { get; set; }
}
