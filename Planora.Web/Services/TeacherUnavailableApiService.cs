using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;
using Planora.Domain.Entities;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Planora.Web.Services
{
    public class TeacherUnavailableApiService
    {
        private readonly HttpClient _httpClient;
        public TeacherUnavailableApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<TeacherUnavailableListDto>> GetListAllAsync()
        {
            var response = await _httpClient.
                GetFromJsonAsync<List<TeacherUnavailableListDto>>($"TeacherUnavailables/GetListAll");
            return response!;
        }

        public async Task<List<TeacherListDto>> GetListTeacherAllAsync()
        {
            var response = await _httpClient.
                GetFromJsonAsync<List<TeacherListDto>>($"Teachers/GetListAll");
            return response!;
        }
        public async Task<List<TeacherUnavailableListDto>> GetUnavailableByTeacherIdAsync(Guid teacherId)
        {
            var response = await _httpClient.
                GetFromJsonAsync<List<TeacherUnavailableListDto>>($"TeacherUnavailables/GetByTeacherId/{teacherId}");
            return response!;
        }
        public async Task<CreatedTeacherUnavailableDto> SaveAsync(CreateTeacherUnavailableCommand createTeacherUnavailableCommand)
        {
            var response = await _httpClient.PostAsJsonAsync("TeacherUnavailables/Add", createTeacherUnavailableCommand);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CreatedTeacherUnavailableDto>();

            return responseBody!;
        }

        public async Task<UpdatedTeacherUnavailableDto> UpdateAsync(UpdateTeacherUnavailableCommand updateTeacherUnavailableCommand)
        {


            var response = await _httpClient.PutAsJsonAsync("TeacherUnavailables/Update", updateTeacherUnavailableCommand);

            if (!response.IsSuccessStatusCode)
                return null;
            var responseBody = await response.Content.ReadFromJsonAsync<UpdatedTeacherUnavailableDto>();

            return responseBody!;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"TeacherUnavailables/DeleteById/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
