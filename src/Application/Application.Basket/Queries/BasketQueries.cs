using System.Data.SqlClient;
using System.Threading.Tasks;
using Application.Basket.Queries.DTO;
using Dapper;

namespace Application.Basket.Queries
{
    public class BasketQueries
    {
        private readonly string _connectionString;

        public BasketQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BasketDTO> GetBasket(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<BasketDTO>("");
            }
        }
    }
}
