using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Menu.Application.Queries.DTO;

namespace Menu.Application.Queries
{
    public class ProductQueries
    {
        private readonly string _connectionString;

        public ProductQueries(string connectionString)
        {
            _connectionString = connectionString;
            SetPizzaIngredientMapping();
        }

        //public async Task<IReadOnlyList<ProductDTO>> GetAllProductsAsync() //todo implement after TPT is available
        //{
        //    return (await _productRepository.GetAll())
        //        .Select(i => _mapper.Map<ProductDTO>(i))
        //        .ToList();
        //}

        //public async Task<ProductDTO> GetProductByIdAsync(int id)
        //{
        //    return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        //}

        public async Task<IngredientDTO> GetIngredientByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            return await connection.QueryFirstOrDefaultAsync<IngredientDTO>(
                @$"
            SELECT 
                 [Id]
                ,[Name]
                ,[Description]
                ,[UnitPrice]
                ,[AvailableQuantity]
                ,[IsSpicy]
                ,[IsVegetarian]
                ,[IsVegan]                
            FROM [Menu].[Ingredients]
            WHERE [Id] = {id}");
        }

        public async Task<IReadOnlyList<IngredientDTO>> GetAllIngredientsAsync()
        {
            await using var connection = new SqlConnection(_connectionString);

            return (await connection.QueryAsync<IngredientDTO>(
                @"
            SELECT 
                 [Id]
                ,[Name]
                ,[Description]
                ,[UnitPrice]
                ,[AvailableQuantity]
                ,[IsSpicy]
                ,[IsVegetarian]
                ,[IsVegan]                
            FROM [Menu].[Ingredients]"
                )).ToList();
        }

        public async Task<PizzaDTO> GetPizzaByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            PizzaDTO resultPizza = null;

            var queryResult = await connection.QueryAsync<PizzaDTO, PizzaIngredientDTO, PizzaDTO>(
                $@"
            SELECT p.[Id]
                  ,p.[Name]
                  ,p.[Description]
                  ,p.[UnitPrice]
	              ,i.[Id] as IngredientId
                  ,i.[Name] as IngredientName
	              ,i.[Description] as IngredientDescription
              FROM [Menu].[Pizzas] p
              INNER JOIN [Menu].[PizzaIngredient] pIn on pIn.PizzaId=p.Id
              INNER JOIN [Menu].[Ingredients] i on pIn.IngredientId=i.Id
              WHERE p.[Id]={id}",
                (pizza, pizzaIngredient) =>
                {
                    if (resultPizza == null)
                    {
                        resultPizza = pizza;
                        resultPizza.Ingredients = new List<PizzaIngredientDTO>();
                    }

                    resultPizza.Ingredients.Add(pizzaIngredient);
                    return resultPizza;
                },
                splitOn: "IngredientId");

            return queryResult.FirstOrDefault();
        }

        public async Task<IReadOnlyList<PizzaDTO>> GetAllPizzasAsync()
        {
            await using var connection = new SqlConnection(_connectionString);

            return (await connection.QueryAsync<PizzaDTO>(
                @"
            SELECT 
                 [Id]
                ,[Name]
                ,[Description]
                ,[UnitPrice]                                
            FROM [Menu].[Pizzas]"
            )).ToList();
        }

        private void SetPizzaIngredientMapping()
        {
            SqlMapper.SetTypeMap(
                typeof(PizzaIngredientDTO),
                new CustomPropertyTypeMap(
                    typeof(PizzaIngredientDTO),
                    (type, columnName) =>
                    {
                        return columnName switch
                        {
                            "IngredientId" => type.GetProperty("Id"),
                            "IngredientName" => type.GetProperty("Name"),
                            "IngredientDescription" => type.GetProperty("Description"),
                            _ => null
                        };
                    })
            );
        }
    }
}
