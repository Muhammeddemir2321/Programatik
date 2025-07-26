namespace Planora.Application.Features.LectureDistributionOptionFeature.Queries.ListAllLectureDistributionOption;

public class LectureDistributionOptionListDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int TotalHours { get; set; }
    public List<int> Distribution { get; set; } = [];
}
