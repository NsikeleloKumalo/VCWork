namespace DBTheRideYouRentTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Driver")]
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [StringLength(10)]
        public string Driver_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverName { get; set; }

        [Required]
        [StringLength(100)]
        public string DriverAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverEmail { get; set; }

        [StringLength(20)]
        public string DriverContactNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
