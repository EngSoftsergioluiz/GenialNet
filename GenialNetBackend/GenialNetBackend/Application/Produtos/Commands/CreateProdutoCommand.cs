using FluentValidation;
using GenialNetBackend.Application.Produtos.Repository;
using GenialNetBackend.Domain;
using GenialNetBackend.Persistence;
using MediatR;

namespace GenialNetBackend.Application.Produtos.Commands
{
    public class CreateProdutoCommand : IRequest<int>
    {
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string UnidadeMedida { get; set; }
    }

    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<CreateProdutoCommand> _validator;

        public CreateProdutoCommandHandler(ApplicationDbContext context, IValidator<CreateProdutoCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<int> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var produto = new Produto
            {
                Descricao = request.Descricao,
                Marca = request.Marca,
                UnidadeMedida = request.UnidadeMedida
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync(cancellationToken);
            return produto.Id;
        }

    }
}
