using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;
using Shared.Domain;

namespace Menu.Application.Queries
{
    public class ProductQueries
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IMapper _mapper;

        public ProductQueries(IRepository<Ingredient> ingredientRepository, IMapper mapper,
            IRepository<Pizza> pizzaRepository, IRepository<Product> productRepository)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _pizzaRepository = pizzaRepository;
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyList<ProductDTO>> GetAllProductsAsync()
        {
            return (await _productRepository.GetAll())
                .Select(i => _mapper.Map<ProductDTO>(i))
                .ToList();
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
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
