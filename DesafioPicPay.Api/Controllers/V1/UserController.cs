using DesafioPicPay.Api.Controllers.Base;
using DesafioPicPay.Application.Features.User.Commands.CreateTransaction;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [HttpPost("transaction")]
        public async Task<IActionResult> Transaction([FromBody] CreateTransactionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}