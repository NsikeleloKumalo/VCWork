using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketDatabase.Models
{
    public class StoreModel
    {

        [Required]
        [Key]
        public int Store_Id { get; set; }

        public string StoreName { get; set; }


        public string Date_Creation { get; set; }

        [Display(Name ="CustomerModel")]

        public int Customer_Id { get; set; }
        [ForeignKey("Customer_Id")]

        public virtual CustomerModel Customer { get; set; }

    }
}
