using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketDatabase.Models
{
    public class OwnerModel
    {
        [Required]
        [Key]
        public int Owner_Id { get; set; }
        public string OwnerName { get; set; }

        public string OwnerSurname { get; set; }

        public int OwnerPhone { get; set; }

        [Display(Name = "CustomerModel")]

        public int Store_Id { get; set; }
        [ForeignKey("Store_Id")]

        public virtual StoreModel Store { get; set; }


    }
}
