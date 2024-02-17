using dapperwebapi.ViewModel;

namespace dapperwebapi.Servcies
{
    public interface ICompanyService
    {
        public Task<IEnumerable<CompanyModel>> GetCompanies();
        public Task<CompanyModel> GetCompany(int id);
        Task<CompanyModel> AddCompany(CompanyModel company);

        public Task UpdateCompany(int id, CompanyModel company);
        public Task DeleteCompany(int id);
    }
}
