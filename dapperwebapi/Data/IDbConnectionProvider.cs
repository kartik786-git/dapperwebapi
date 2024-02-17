using System.Data;

namespace dapperwebapi.Data
{
    public interface IDbConnectionProvider
    {
        IDbConnection CreateConnection();
    }
}
