using GenialNetBackend.Application.Produtos.Commands;
using GenialNetBackend.Application.Produtos.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenialNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProdutoCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            var produtos = await _mediator.Send(new GetProdutosQuery());
            return Ok(produtos);
        }
    }
}
