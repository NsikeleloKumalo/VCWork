using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class EmployeeModel
    {
        [Required] [Key]public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

    }
}
