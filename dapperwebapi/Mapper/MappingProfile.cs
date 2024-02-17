using AutoMapper;
using dapperwebapi.EntityModel;
using dapperwebapi.ViewModel;

namespace dapperwebapi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap(); ;
        }
    }
}
