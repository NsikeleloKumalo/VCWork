using System.ComponentModel.DataAnnotations;

namespace LocationsDatabase.Models
{
    public class LocationModel
    {
        [Required] [Key] public int LocationId { get; set; }
        public string LocationName { get; set; }

        public string LocationAddress { get; set; }
        public string ProjectName { get; set; }
      
    }
}
