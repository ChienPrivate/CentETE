using CentETE.Application.Feartures.Store.Commands;
using CentETE.Application.Feartures.Store.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentETE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAPIController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StoreAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("store")]
        public async Task<IActionResult> Create(CreateStoreCommand command)
        {
            var storeId = await _mediator.Send(command);
            return Ok(storeId);
        }

        [HttpGet("store/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetStoreByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("stores")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStoresQuery());
            return Ok(result);
        }

    }
}
