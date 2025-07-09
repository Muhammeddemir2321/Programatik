using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Models;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;

namespace Planora.Web.Services;

public class LessonScheduleGroupApiService
{
    private readonly HttpClient _httpClient;
    public LessonScheduleGroupApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CreatedLessonScheduleGroupDto> SaveAsync(CreateLessonScheduleGroupCommand createLessonScheduleGroupCommand)
    {
        var response = await _httpClient.PostAsJsonAsync("LessonScheduleGroups/Add", createLessonScheduleGroupCommand);

        if (!response.IsSuccessStatusCode)
            return null;

        var responseBody = await response.Content.ReadFromJsonAsync<CreatedLessonScheduleGroupDto>();

        return responseBody!;
    }

    public async Task<LessonScheduleGroupWithLessonSchedulesGetByIdDto> GetAsync(Guid groupId)
    {
        var response = await _httpClient.
            GetFromJsonAsync<LessonScheduleGroupWithLessonSchedulesGetByIdDto>($"LessonScheduleGroups/GetById/{groupId}");
        return response!;
    }
    public async Task<List<LessonScheduleGroupListDto>> GetAllAsync()
    {
        var response = await _httpClient.
            GetFromJsonAsync<List<LessonScheduleGroupListDto>>($"LessonScheduleGroups/GetAll");

        return response!;
    }
}
