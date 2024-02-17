namespace dapperwebapi.ViewModel
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
