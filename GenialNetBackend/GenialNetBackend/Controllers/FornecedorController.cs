using GenialNetBackend.Application.Fornecedor.Commands;
using GenialNetBackend.Application.Fornecedor.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenialNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FornecedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarFornecedor([FromBody] CreateFornecedorCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetFornecedores()
        {
            var fornecedores = await _mediator.Send(new GetFornecedoresQuery());
            return Ok(fornecedores);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarProdutos(UpdateProdutosFornecedorCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("Produtos atualizados com sucesso") : BadRequest("Erro ao atualizar produtos");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverProdutos([FromBody] RemoveProdutoFornecedorCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound("Fornecedor não encontrado ou produtos inválidos.");
            }
            return Ok("Produtos removidos com sucesso.");
        }
    }
}
