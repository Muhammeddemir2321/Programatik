using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Constants;
using Planora.Application.Features.ClassSectionFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;

public class ListAllClassSectionQuery : IRequest<ClassSectionListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassSectionClaimConstants.List };
}
