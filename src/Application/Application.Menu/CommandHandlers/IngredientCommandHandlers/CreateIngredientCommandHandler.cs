using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands.IngredientCommands;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers.IngredientCommandHandlers
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, IngredientDTO>
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

        public async Task<IngredientDTO> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(
                request.Name,
                request.Description,
                request.UnitPrice,
                request.IsSpicy,
                request.IsVegetarian,
                request.IsVegan,
                request.AvailableQuantity
            );

            await _ingredientRepository.AddAsync(ingredient);
            await _unitOfWork.SaveEntitiesAsync();

            return _mapper.Map<IngredientDTO>(ingredient);
        }
    }
}
