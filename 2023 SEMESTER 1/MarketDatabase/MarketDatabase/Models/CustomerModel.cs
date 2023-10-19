using System.ComponentModel.DataAnnotations;

namespace MarketDatabase.Models
{
    public class CustomerModel
    {
        [Required]
        [Key]
        public int Customer_Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }  
        public string CustomerPhone { get; set; }   
    }
}
