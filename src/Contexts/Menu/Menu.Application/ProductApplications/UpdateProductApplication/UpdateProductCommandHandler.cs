﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Menu.Application.ProductApplications.UpdateProductApplication
{
    public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public UpdateProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        protected override async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id);

            if (productToUpdate == null)
            {
                throw new RecordNotFoundException(request.Id);
            }

            if (request.Name != null)
            {
                productToUpdate.SetName(request.Name);
            }

            if (request.Description != null)
            {
                productToUpdate.SetDescription(request.Description);
            }

            if (request.UnitPrice.HasValue)
            {
                productToUpdate.SetUnitPrice(request.UnitPrice.Value);
            }

            if (request.AvailableQuantity.HasValue)
            {
                if (request.AvailableQuantity > productToUpdate.AvailableQuantity)
                {
                    productToUpdate.AddToWarehouse(request.AvailableQuantity.Value -
                                                 productToUpdate.AvailableQuantity);
                }
                if (request.AvailableQuantity < productToUpdate.AvailableQuantity)
                {
                    productToUpdate.TakeFromWarehouse(productToUpdate.AvailableQuantity -
                                                    request.AvailableQuantity.Value);
                }
            }

            if (request.Type.HasValue)
            {
                productToUpdate.SetType(request.Type.Value);
            }
        }
    }
}