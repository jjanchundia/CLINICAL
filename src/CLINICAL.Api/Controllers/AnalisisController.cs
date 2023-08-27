using CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetAllQuery;
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
    }
}