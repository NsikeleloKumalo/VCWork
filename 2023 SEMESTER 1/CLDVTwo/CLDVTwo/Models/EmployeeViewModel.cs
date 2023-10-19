using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLDVTwo.Models
{
    public class EmployeeViewModel
    {

        public List<EmployeeModel>? Employee { get; set; }
        public SelectList? EmployeeName { get; set; }
        public string? EmployeeJobDesc { get; set; }
        public string? SearchString { get; set; }
    }
}
