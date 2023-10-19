using System.ComponentModel.DataAnnotations;

namespace VarsityDatabase.Models
{
    public class CampusModel
    {
        
        [Required] [Key] public int Campus_ID { get; set; }

        public string Campus_Name { get; set; }

        public string Campus_Address { get; set; }

    }
}
