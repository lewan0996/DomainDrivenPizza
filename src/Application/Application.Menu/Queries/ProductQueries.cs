using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;

namespace Application.Menu.Queries
{
    public class ProductQueries
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IMapper _mapper;

        public ProductQueries(IRepository<Ingredient> ingredientRepository, IMapper mapper,
            IRepository<Pizza> pizzaRepository)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _pizzaRepository = pizzaRepository;
        }

        public async Task<IngredientDTO> GetIngredientByIdAsync(int id)
        {
            return _mapper.Map<IngredientDTO>(await _ingredientRepository.GetByIdAsync(id));
        }

        public async Task<IReadOnlyList<IngredientDTO>> GetAllIngredientsAsync()
        {
            return (await _ingredientRepository.GetAll())
                .Select(i => _mapper.Map<IngredientDTO>(i))
                .ToList();
        }

        public async Task<PizzaDTO> GetPizzaByIdAsync(int id)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);
            return _mapper.Map<PizzaDTO>(pizza);
        }

        public async Task<IReadOnlyList<PizzaDTO>> GetAllPizzasAsync()
        {
            return (await _pizzaRepository.GetAll())
                .Select(p => _mapper.Map<PizzaDTO>(p))
                .ToList();
        }
    }
}
