using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class LessonScheduleGroup : BaseTimeStampEntity<Guid>, ISchoolEntity
{
    public Guid SchoolId { get; set; }
    public School School { get; set; }

    public int Semester { get; set; }           // Güz, Bahar vs.
    public int Year { get; set; }               // 2024, 2025...

    public string Description { get; set; }     // "Otomatik oluşturulan versiyon", "Elle düzenlenen", vs.
    public bool IsActive { get; set; }          // Şu an kullanılan plan mı?
    public ICollection<LessonSchedule> LessonSchedules { get; set; }
    public LessonScheduleGroup()
    {
        LessonSchedules = new HashSet<LessonSchedule>();
    }

}
