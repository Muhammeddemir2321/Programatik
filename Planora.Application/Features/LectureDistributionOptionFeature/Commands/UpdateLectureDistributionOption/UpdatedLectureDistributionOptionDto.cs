namespace Planora.Application.Features.LectureDistributionOptionFeature.Commands.UpdateLectureDistributionOption;

public class UpdatedLectureDistributionOptionDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int TotalHours { get; set; }
    public List<int> Distribution { get; set; } = [];
}
