namespace DBTheRideYouRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inspector")]
    public partial class Inspector
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inspector()
        {
            Rentals = new HashSet<Rental>();
            ReturnCars = new HashSet<ReturnCar>();
        }

        [Key]
        [StringLength(6)]
        public string Inspector_no { get; set; }

        [Required]
        [StringLength(50)]
        public string InspectorName { get; set; }

        [Required]
        [StringLength(50)]
        public string InspectorEmail { get; set; }

        [StringLength(20)]
        public string InspectorMobile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnCar> ReturnCars { get; set; }
    }
}
