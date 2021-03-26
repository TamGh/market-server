using Market.Applictaion.DTOs;
using Market.Applictaion.UseCases.Commands;
using Market.Applictaion.UseCases.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var quesryResult = await _mediator.Send(new GetProductsQuery());
            return Ok(quesryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            var quesryResult = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(quesryResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product)
        {
            var commandResult = await _mediator.Send(new AddProdcutCommand(product));
            return Ok(commandResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO product)
        {
            var commandResult = await _mediator.Send(new UpdateProdcutCommand(product));
            return Ok(commandResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var commandResult = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(commandResult);
        }
    }
}
