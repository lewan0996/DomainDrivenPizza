using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Menu.Application.PizzaApplications.CreatePizzaApplication
{
    public class CreatePizzaCommandHandler : IRequestHandler<CreatePizzaCommand, PizzaDTO>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePizzaCommandHandler(IRepository<Ingredient> ingredientRepository,
            IRepository<Pizza> pizzaRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _pizzaRepository = pizzaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<PizzaDTO> Handle(CreatePizzaCommand request, CancellationToken cancellationToken)
        {
            var pizza = new Pizza(request.Name, request.Description, request.UnitPrice);

            var getIngredientTasks = request.IngredientIds
                .Select(GetIngredientTask).ToArray();

            var ingredients = await Task.WhenAll(getIngredientTasks);

            foreach (var ingredient in ingredients)
            {
                pizza.AddIngredient(ingredient);
            }

            await _pizzaRepository.AddAsync(pizza);
            await _unitOfWork.SaveEntitiesAsync();

            return _mapper.Map<PizzaDTO>(pizza);
        }

        private async Task<Ingredient> GetIngredientTask(int ingredientId)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
            if (ingredient == null)
            {
                throw new RecordNotFoundException(ingredientId);
            }

            return ingredient;
        }
    }
}
