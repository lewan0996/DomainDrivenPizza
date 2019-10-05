using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands.ProductCommands;
using Application.Shared.Exceptions;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers.ProductCommandHandlers
{
    public class DeleteProductCommandHandler: AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);
            if (productToDelete == null)
            {
                throw new RecordNotFoundException(request.Id);
            }

            _productRepository.Delete(productToDelete);
        }
    }
}
