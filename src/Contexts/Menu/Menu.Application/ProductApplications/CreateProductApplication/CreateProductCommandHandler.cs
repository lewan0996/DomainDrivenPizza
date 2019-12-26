using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;
using Shared.Domain;

namespace Menu.Application.ProductApplications.CreateProductApplication
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
