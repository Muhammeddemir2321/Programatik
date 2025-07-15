namespace Planora.Application.Features.LessonScheduleFeature.Scheduling;

public static class LectureDistributionStrategy
{
    public static IReadOnlyDictionary<int, List<List<int>>> LectureHourSplitOptions { get; } = new Dictionary<int, List<List<int>>>
{
    { 1, new List<List<int>> { new() { 1 } } },
    { 2, new List<List<int>> { new() { 2 } } },
    { 3, new List<List<int>> { new() { 2, 1 } } },
    { 4, new List<List<int>> { new() { 2, 2 } } },
    { 5, new List<List<int>> { new() { 2, 2, 1 }, new() { 3, 2 } } },
    { 6, new List<List<int>> { new() { 2, 2, 2 }, new() { 3, 3 } } },
    { 7, new List<List<int>> { new() { 4, 2, 1 } } },
    { 8, new List<List<int>> { new() { 4, 4 } } },
    { 9, new List<List<int>> { new() { 4, 4, 1 }, new() { 3, 3, 3 } } },
    { 10, new List<List<int>> { new() { 4, 4, 2 }, new() { 3, 4, 3 } } },
    { 12, new List<List<int>> { new() { 4, 4, 4 }, new() { 3, 3, 3, 3 } } },
    { 16, new List<List<int>> { new() { 4, 4, 4, 4 } } }
};

    public static List<List<int>> GetOptions(int totalHours)
    {
        return LectureHourSplitOptions.TryGetValue(totalHours, out var options)
        ? options.Select(option => new List<int>(option)).ToList()
        : new List<List<int>> { new() { totalHours } };
    }
    public static List<int> GetDefault(int totalHours)
    {
        return GetOptions(totalHours).First().OrderByDescending(option => option).ToList();
    }
}
