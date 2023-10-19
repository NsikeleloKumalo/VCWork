using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class StoreModel
    {
        [Required] [Key] public int StoreID { get; set; }

        public string StoreName { get; set; }

        public  int CustomerID  { get; set; }

        public int EmployeeID { get; set; }


        public virtual CustomerModel Customer { get; set; }
        public virtual EmployeeModel Employee { get; set; }
   
    }
}
