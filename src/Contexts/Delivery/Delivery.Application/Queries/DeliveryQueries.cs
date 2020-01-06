using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Delivery.Application.Queries.DTO;

namespace Delivery.Application.Queries
{
    public class DeliveryQueries
    {
        private readonly string _connectionString;

        public DeliveryQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IReadOnlyList<OrderDTO>> GetSupplierOrdersAsync(int supplierId)
        {
            await using var connection = new SqlConnection(_connectionString);

            var query = $@"SELECT o.[Id]
                              ,[Address_City] as City
                              ,[Address_AddressLine1] as AddressLine1
                              ,[Address_AddressLine2] as AddressLine2
                              ,[Address_ZipCode] as ZipCode
                              ,[Client_FirstName] as FirstName
                              ,[Client_LastName] as LastName
                              ,[Client_EmailAddress] as EmailAddress
                              ,[Client_PhoneNumber] as PhoneNumber
                              ,[SupplierId]
                              ,[Status]
	                          ,[ProductId]
                              ,[Quantity]
                              ,[UnitPrice]
                          FROM [Delivery].[Orders] o
                          INNER JOIN [Delivery].[OrderItems] oi on oi.[OrderId]=o.[Id]
                          WHERE SupplierId={supplierId}";
            
            return (await connection.QueryAsync<OrderDTO,OrderItemDTO,OrderDTO>(
                query,(dto, itemDTO) =>
                {
                    if (dto.Items == null)
                    {
                        dto.Items = new List<OrderItemDTO>();
                    }

                    dto.Items.Add(itemDTO);

                    return dto;
                },splitOn:"ProductId")).ToList();
        }
    }
}
