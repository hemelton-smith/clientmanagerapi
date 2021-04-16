using ClientManager.Integration.Sql.Connections;
using Microsoft.Extensions.Configuration;
using System;

namespace ClientManager.Web.Main.Infrastructure
{
    public class DbSettings: IDbSettings
    {
        private readonly IConfiguration _configuration;

        public DbSettings(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public string ConnectionString => "Server=tcp:clientmanagerdbserver.database.windows.net,1433;Initial Catalog=ClientManager;Persist Security Info=False;User ID=clientmanager;Password=Hemelton-1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=false";
    }
}
