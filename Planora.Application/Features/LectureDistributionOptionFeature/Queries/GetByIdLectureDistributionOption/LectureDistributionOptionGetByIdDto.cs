namespace Planora.Application.Features.LectureDistributionOptionFeature.Queries.GetByIdLectureDistributionOption;

public class LectureDistributionOptionGetByIdDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int TotalHours { get; set; }
    public List<int> Distribution { get; set; } = [];
}
