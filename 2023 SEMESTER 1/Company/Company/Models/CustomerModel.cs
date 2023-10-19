using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class CustomerModel
    {
        [Required] [Key] public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
