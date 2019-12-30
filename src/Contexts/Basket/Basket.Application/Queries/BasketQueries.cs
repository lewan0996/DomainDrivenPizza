using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.Application.Queries.DTO;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Basket.Application.Queries
{
    public class BasketQueries
    {
        private readonly string _connectionString;

        public BasketQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BasketDTO> GetBasketAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            BasketDTO resultBasket = null;

            var queryResult = await connection.QueryAsync<BasketDTO, BasketItemDTO, BasketDTO>(
                "SELECT b.[ProductId] as BasketId, bi.[ProductId] as BasketItemId, bi.[ProductId], bi.[Quantity] " +
                "FROM [CustomerBasket].[Baskets] b " +
                "INNER JOIN [CustomerBasket].[BasketItems] bi on bi.BasketId = b.[ProductId] " +
                $"WHERE b.[ProductId]={id}",
                (basket, basketItem) =>
                {
                    if (resultBasket == null)
                    {
                        resultBasket = basket;
                        resultBasket.Items = new List<BasketItemDTO>();
                    }
                    resultBasket.Items.Add(basketItem);
                    return resultBasket;

                },
                splitOn: "BasketItemId");

            return queryResult.FirstOrDefault();
        }
    }
}
