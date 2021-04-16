using ClientManager.Domain.Clients;
using ClientManager.Integration.Sql.Connections;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManager.Integration.Sql.Clients
{
    public class ClientGateway : IClientGateway
    {
        private readonly IClientManagerDbConnectionContext _context;
        private IDbTransaction DbTransaction => _context.GetTransaction();
        private IDbConnection DbConnection => _context.GetConnection();

        public ClientGateway(IClientManagerDbConnectionContext context)
        {
            _context = context;
        }

        public async Task CreateClient(Client client)
        {
            var sql = @"INSERT INTO [Client]
                       ([Id]
                       ,[FirstName]
                       ,[LastName]
                       ,[Gender]
                       ,[CellNumber]
                       ,[WorkNumber])
                 VALUES
                       (@Id
                       , @FirstName
                       , @LastName
                       , @Gender
                       , @CellNumber
                       , @WorkNumber)";

            await DbConnection.ExecuteAsync(sql, client, DbTransaction);

        }

        public async Task UpdateClient(Client client)
        {
            var sql = @"UPDATE [Client] SET
                                       [FirstName] = @FirstName
                                      ,[LastName] = @LastName
                                      ,[Gender] = @Gender
                                      ,[CellNumber] = @CellNumber
                                      ,[WorkNumber] = @WorkNumber
                                 WHERE [Id] = @Id";

            await DbConnection.ExecuteAsync(sql, client, DbTransaction);

        }
        public async Task DeleteClient(Guid ClientId)
        {
            var sql = @"DELETE  FROM [Client] WHERE [Id] = @Id";
            await DbConnection.ExecuteAsync(sql, new { Id = ClientId }, DbTransaction);
        }

        public async Task<Client> GetAllClientById(Guid clientID)
        {
            return await DbConnection.QueryFirstOrDefaultAsync<Client>(@"SELECT  [Id]
                                                                                  ,[FirstName]
                                                                                  ,[LastName]
                                                                                  ,[Gender]
                                                                                  ,[CellNumber]
                                                                                  ,[WorkNumber]
                                                                              FROM [Client] WHERE[Id] = @id", new { id = clientID }, DbTransaction);
        }



        public async Task<List<ClientInformation>> GetClientsInformation()
        {
            var clients = await DbConnection.QueryAsync<ClientInformation>(@"SELECT 
      c.[Id],
      c.[FirstName]
      ,c.[LastName]
      ,c.[Gender]
	  ,a.[Street]
	  ,a.[Town]
	  ,a.[Code]
	  ,t.[Type]
  FROM [Client] c INNER JOIN [dbo].[Address] a on a.ClientId = c.Id JOIN  [AddressType] t ON a.[Type] = t.[Id] order by c.[Id] ", null, DbTransaction);
            return clients.ToList();
        }
        
        public async Task<List<Client>> GetAllClients()
        {
            var clients = await DbConnection.QueryAsync<Client>(@"SELECT  [Id]
                                                                                  ,[FirstName]
                                                                                  ,[LastName]
                                                                                  ,[Gender]
                                                                                  ,[CellNumber]
                                                                                  ,[WorkNumber]
                                                                              FROM [Client]", null, DbTransaction);
            return clients.ToList();
        }

        public async Task InsertAddress(Guid clientId)
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

            await DbConnection.ExecuteAsync(sql, new { ClientId = clientId }, DbTransaction);
        }
    }
}
