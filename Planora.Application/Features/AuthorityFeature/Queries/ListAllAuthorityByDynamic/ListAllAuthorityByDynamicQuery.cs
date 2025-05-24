using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Models;

namespace Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthorityByDynamic
{
    public class ListAllAuthorityByDynamicQuery : IRequest<AuthorityListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Query { get; set; }
    }
}
