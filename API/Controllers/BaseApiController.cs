using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??=
             HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandelResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            if (result.Value == null && result.IsSuccess)
                return NotFound();
            return BadRequest(result.Error);
        }
    }
}