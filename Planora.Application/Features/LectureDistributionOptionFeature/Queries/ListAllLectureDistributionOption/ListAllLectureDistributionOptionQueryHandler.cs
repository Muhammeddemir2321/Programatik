using AutoMapper;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Models;
using Planora.Application.Features.SchoolScheduleSettingFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Queries.ListAllLectureDistributionOption;

public class ListAllLectureDistributionOptionQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<ListAllLectureDistributionOptionQuery, LectureDistributionOptionListModel>
{
    public async Task<LectureDistributionOptionListModel> Handle(ListAllLectureDistributionOptionQuery request, CancellationToken cancellationToken)
    {
        var options = await planoraUnitOfWork.LectureDistributionOptions.GetListAsync(
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
        );

        return new LectureDistributionOptionListModel
        {
            Index = options.Index,
            Size = options.Size,
            Count = options.Count,
            Pages = options.Pages,
            HasNext = options.HasNext,
            HasPrevious = options.HasPrevious,
            Items = options.Items.Select(option => new LectureDistributionOptionListDto
            {
                Id = option.Id,
                TotalHours = option.TotalHours,
                Distribution = string.IsNullOrWhiteSpace(option.Distribution)
                    ? new()
                    : JsonSerializer.Deserialize<List<int>>(option.Distribution) ?? new()
            }).ToList()
        };
    }
}
