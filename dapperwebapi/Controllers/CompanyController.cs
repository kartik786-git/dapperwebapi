using dapperwebapi.Servcies;
using dapperwebapi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace dapperwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetCompanies();
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyModel company)
        {
            _logger.LogInformation($"ener request");
            var createdProductReponse = await _companyService.AddCompany(company);
            return StatusCode((int)HttpStatusCode.Created, new { createdProductReponse });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, 
            [FromBody] CompanyModel company)
        {

            var companyExists = await _companyService.GetCompany(id);
            if (companyExists == null)
                return NotFound();
            await _companyService.UpdateCompany(id, company);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var companyExists = await _companyService.GetCompany(id);
            if (companyExists == null)
                return NotFound();
            await _companyService.DeleteCompany(id);
            return NoContent();

        }
    }
}
