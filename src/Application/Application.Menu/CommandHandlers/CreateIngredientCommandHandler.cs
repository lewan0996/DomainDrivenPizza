using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, IngredientDto>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIngredientCommandHandler(IRepository<Ingredient> ingredientRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IngredientDto> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var name = new ProductName(request.Name);
            var description = new ProductDescription(request.Description);

            var ingredient = new Ingredient(
                name,
                description,
                request.UnitPrice,
                request.IsSpicy,
                request.IsVegetarian,
                request.IsVegan,
                request.AvailableQuantity
            );

            await _ingredientRepository.Add(ingredient);
            await _unitOfWork.SaveEntitiesAsync();

            return _mapper.Map<IngredientDto>(ingredient);
        }
    }
}
