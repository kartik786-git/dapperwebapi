using AutoMapper;
using dapperwebapi.EntityModel;
using dapperwebapi.Repository;
using dapperwebapi.ViewModel;

namespace dapperwebapi.Servcies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository,
            IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyModel>> GetCompanies()
        {
           var compines = await _companyRepository.GetCompanies();
            var response = _mapper.Map<IEnumerable<CompanyModel>>(compines);
            return response;
        }

        public async Task<CompanyModel> GetCompany(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            var response = _mapper.Map<CompanyModel>(company);
            return response;
        }
        public async Task<CompanyModel> AddCompany(CompanyModel company)
        {
            var entity = _mapper.Map<Company>(company);
            var createCompany = await _companyRepository.CreateCompany(entity);
            var response = _mapper.Map<CompanyModel>(createCompany);
            return response;
        }

        public async Task DeleteCompany(int id)
        {
            await _companyRepository.DeleteCompany(id);
        }

       

        public async Task UpdateCompany(int id, CompanyModel company)
        {
            var entity = _mapper.Map<Company>(company);
            await _companyRepository.UpdateCompany(id, entity);
        }
    }
}
