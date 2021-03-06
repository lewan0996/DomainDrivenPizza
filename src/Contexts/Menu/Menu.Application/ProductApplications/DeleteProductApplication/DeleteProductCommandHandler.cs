﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Domain;
using Shared.Domain.Exceptions;

namespace Menu.Application.ProductApplications.DeleteProductApplication
{
    // ReSharper disable once UnusedType.Global
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
                throw new RecordNotFoundException(request.Id, nameof(Product));
            }

            _productRepository.Delete(productToDelete);
        }
    }
}
