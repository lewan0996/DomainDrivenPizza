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
        private readonly IMapper _mapper;
        public ProductQueries(IRepository<Ingredient> ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IngredientDto> GetIngredientByIdAsync(int id)
        {
            return _mapper.Map<IngredientDto>(await _ingredientRepository.GetById(id));
        }

        public async Task<IReadOnlyList<IngredientDto>> GetAllIngredientsAsync()
        {
            return (await _ingredientRepository.GetAll())
                .Select(i => _mapper.Map<IngredientDto>(i))
                .ToList();
        }
    }
}
