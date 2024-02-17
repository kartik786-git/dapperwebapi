using dapperwebapi.EntityModel;

namespace dapperwebapi.Repository
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> CreateCompany(Company company);
        public Task UpdateCompany(int id, Company company);
        public Task DeleteCompany(int id);
    }
}
