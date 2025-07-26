namespace Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;

public class CreatedLectureDistributionOptionDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int TotalHours { get; set; }
    public List<int> Distribution { get; set; } = [];
}
