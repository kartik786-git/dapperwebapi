using Dapper;
using dapperwebapi.Data;
using dapperwebapi.EntityModel;

namespace dapperwebapi.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;


        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Company";
            using(var conneciton = _dbConnectionProvider.CreateConnection())
            {
               var compnines = await conneciton.QueryAsync<Company>(query);
                return compnines.ToList();
            }
        }

        public async Task<Company> GetCompany(int id)
        {
            var query = "SELECT * FROM Company WHERE Id = @Id";
            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
                return company;
            }
        }

        public CompanyRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            var query = "INSERT INTO Company (Name, Address, Country) " +
                "VALUES (@Name, @Address, @Country)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            //var parameters = new DynamicParameters();
            //parameters.Add("Name123", company.Name, DbType.String);
            //parameters.Add("Address", company.Address, DbType.String);
            //parameters.Add("Country", company.Country, DbType.String);

            //Dictionary<string, object> queryParameters = new Dictionary<string, object>
            //{
            //    { "Name123", company.Name}
            //};

            using (var connection = _dbConnectionProvider.CreateConnection())
            {

                var id = await connection.ExecuteScalarAsync<int>(query, company).ConfigureAwait(false);
                company.Id = id;
                return company;
            }
        }

        public async Task DeleteCompany(int id)
        {
            var query = "DELETE FROM Company WHERE Id = @Id";
            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

       
        public async Task UpdateCompany(int id, Company company)
        {
            var query = "UPDATE Company SET Name = @Name, " +
                "Address = @Address, Country = @Country WHERE Id = @Id";
            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                await connection.ExecuteAsync(query, company);
            }
        }
    }
}
