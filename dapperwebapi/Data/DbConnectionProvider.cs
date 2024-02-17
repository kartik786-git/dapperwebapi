using dapperwebapi.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace dapperwebapi.Data
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly SqlConnectionsSettings _options;

        public DbConnectionProvider(IOptions<SqlConnectionsSettings> options)
        {
            _options = options.Value;
        }
        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_options.SQLConnectionString);
            connection.Open();
            return connection;
        }
    }
}
