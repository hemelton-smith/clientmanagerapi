using ClientManager.Domain.Addresses;
using ClientManager.Integration.Sql.Connections;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ClientManager.Integration.Sql.Address
{
    public class AddressGateway : IAddressGateway
    {
        private readonly IClientManagerDbConnectionContext _context;
        private IDbTransaction DbTransaction => _context.GetTransaction();
        private IDbConnection DbConnection => _context.GetConnection();
        public AddressGateway(IClientManagerDbConnectionContext context)
        {
            _context = context;
        }

        public async Task InsertAddress(List<Domain.Clients.Address> address)
        {
            var sql = @"INSERT INTO [Address]
           ([Id]
           ,[ClientId]
           ,[Street]
           ,[Town]
           ,[Code]
           ,[Type])
     VALUES
           (@Id
           ,@ClientId
           ,@Street
           ,@Town
           ,@Code
           ,@Type)";
            await DbConnection.ExecuteAsync(sql, address, DbTransaction);
        }

        public async Task DeleteAddress(Guid ClientId)
        {
            var sql = @"DELETE  FROM [Address] WHERE [ClientId] = @Id";
            await DbConnection.ExecuteAsync(sql, new { Id = ClientId }, DbTransaction);
        }

        public async Task<List<Domain.Clients.Address>> GetClientAddresses(Guid ClientId)
        {
            var clientAddresses = await DbConnection.QueryAsync<Domain.Clients.Address>(@"SELECT  
                       [Id]
                      ,[ClientId]
                      ,[Street]
                      ,[Town]
                      ,[Code]
                      ,[Type]
                       FROM [Address] WHERE [ClientId] = @Id", new { Id = ClientId }, DbTransaction);
            return (List<Domain.Clients.Address>)clientAddresses;
        }

        public async Task UpdateClientAddresses(List<Domain.Clients.Address> address)
        {
            var sql = @"UPDATE [Address] SET
                                        [Street] = @Street
                                       ,[Town] = @Town
                                       ,[Code] = @Code
                                      WHERE [ClientId] = @ClientId and [Type]=@Type";

            await DbConnection.ExecuteAsync(sql, address, DbTransaction);
        }
    }
}
