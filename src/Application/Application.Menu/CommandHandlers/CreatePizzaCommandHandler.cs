using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Exceptions;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers
{
    public class CreatePizzaCommandHandler : IRequestHandler<CreatePizzaCommand, PizzaDTO>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IMapper _mapper;

        public CreatePizzaCommandHandler(IRepository<Ingredient> ingredientRepository,
            IRepository<Pizza> pizzaRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _pizzaRepository = pizzaRepository;
            _mapper = mapper;
        }

        //todo try to inherit CreateProductCommandHandler
        public async Task<PizzaDTO> Handle(CreatePizzaCommand request, CancellationToken cancellationToken)
        {
            var name = new ProductName(request.Name);
            var description = new ProductDescription(request.Description);

            var pizza = new Pizza(name, description, request.UnitPrice, request.AvailableQuantity, request.CrustType);

            var getIngredientTasks = request.IngredientIds
                .Select(GetIngredientTask).ToArray();

            var ingredients = await Task.WhenAll(getIngredientTasks);

            foreach (var ingredient in ingredients)
            {
                pizza.AddIngredient(ingredient);
            }

            await _pizzaRepository.AddAsync(pizza);

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
