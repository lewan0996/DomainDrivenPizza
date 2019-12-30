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

            //todo simplify
            var queryResult = await connection.QueryAsync<BasketDTO, BasketItemDTO, BasketDTO>(
                "SELECT b.[Id] as Id, bi.[Id] as BasketItemId, bi.[ProductId], bi.[Quantity] " +
                "FROM [Basket].[Baskets] b " +
                "INNER JOIN [Basket].[BasketItems] bi on bi.BasketId = b.[Id] " +
                $"WHERE b.[Id]={id}",
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
