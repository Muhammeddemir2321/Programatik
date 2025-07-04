using AutoMapper;
using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LectureFeature.Commands;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Commands;
using Planora.Persistence.SeedData;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDatasController : BaseController
    {
        private readonly IMapper _mapper;

        public SeedDatasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSchool()
        {
            CreateSchoolCommand c = new();
            var schools = SeedTestData.SetSeedDataSchool();
            foreach (var item in schools)
            {
                var command = _mapper.Map<CreateSchoolCommand>(item);
                var result = await Mediator.Send(command);
                return Created("", result);
            }
            return Ok();
        }
    }
}
