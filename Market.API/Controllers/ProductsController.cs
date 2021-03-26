using Market.Applictaion.DTOs;
using Market.Applictaion.UseCases.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product)
        {
            var commandResult = await _mediator.Send(new AddProdcutCommand(product));
            return Ok(commandResult);
        }
    }
}
