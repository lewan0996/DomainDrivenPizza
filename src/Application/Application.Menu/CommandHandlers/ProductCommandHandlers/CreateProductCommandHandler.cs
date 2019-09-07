using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands.ProductCommands;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers.ProductCommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Type,
                request.UnitPrice,
                request.AvailableQuantity
            );

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveEntitiesAsync();

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
