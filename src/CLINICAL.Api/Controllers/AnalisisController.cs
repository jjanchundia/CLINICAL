using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.UseCase.UseCases.Analisis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analisis.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetByIdQuery;
using CLINICAL.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnalisisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalisis()
        {
            var response = await _mediator.Send(new GetlAllAnalisisQuery());
            return Ok(response);
        }

        [HttpGet("{analisisId:int}")]
        public async Task<IActionResult> ListAnalisisPorId(int analisisId)
        {
            var response = await _mediator.Send(new GetAnalisisByIdQuery() { Id = analisisId });
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateAnalisis(CreateAnalisisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAnalisis([FromBody] UpdateAnalisisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}