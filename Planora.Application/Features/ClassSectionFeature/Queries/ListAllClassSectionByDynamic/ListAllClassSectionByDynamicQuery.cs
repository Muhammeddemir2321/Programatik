using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Constants;
using Planora.Application.Features.ClassSectionFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSectionByDynamic;

public class ListAllClassSectionByDynamicQuery : IRequest<ClassSectionListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassSectionClaimConstants.List };
}
