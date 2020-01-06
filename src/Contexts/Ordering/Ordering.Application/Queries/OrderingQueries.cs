using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Ordering.Application.Queries.DTO;

namespace Ordering.Application.Queries
{
    public class OrderingQueries
    {
        private readonly string _connectionString;

        public OrderingQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<OrderDTO[]> GetOrdersByUserEmail(string email)
        {
            await using var connection = new SqlConnection(_connectionString);

            var query = $@"
                SELECT 
                    o.[Id]
                    ,[Status]
                    ,[Client_FirstName] as FirstName
                    ,[Client_LastName] as LastName
                    ,[Client_EmailAddress] as EmailAddress
                    ,[Client_PhoneNumber] as PhoneNumber
                    ,[Address_City] as City
                    ,[Address_AddressLine1] as AddressLine1
                    ,[Address_AddressLine2] as AddressLine2
                    ,[Address_ZipCode] as ZipCode                  
                    ,[oi].ProductId
                    ,[oi].Quantity
                    ,[oi].UnitPrice
                FROM [Ordering].[Orders] o
                INNER JOIN [Ordering].[OrderItem]  oi on [oi].OrderId=[o].Id
                WHERE Client_EmailAddress = '{email}'";

            return (await connection.QueryAsync<
                OrderDTO, 
                ClientDTO, 
                AddressDTO, 
                OrderItemDTO, 
                OrderDTO>(query,
                (dto, clientDTO, addressDto, orderItemDto) =>
                {
                    dto.Address = addressDto;
                    dto.Client = clientDTO;

                    if (dto.Items == null)
                    {
                        dto.Items = new List<OrderItemDTO>();
                    }

                    dto.Items.Add(orderItemDto);

                    return dto;
                }, splitOn: "FirstName, City, ProductId")).ToArray();
        }
    }
}
