namespace DBTheRideYouRentTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rental")]
    public partial class Rental
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rental()
        {
            ReturnCars = new HashSet<ReturnCar>();
        }

        [Key]
        [StringLength(6)]
        public string Rental_no { get; set; }

        public decimal RentalFee { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(8)]
        public string CarNo { get; set; }

        [Required]
        [StringLength(6)]
        public string Inspector_no { get; set; }

        [Required]
        [StringLength(10)]
        public string Driver_ID { get; set; }

        public virtual Car Car { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Inspector Inspector { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnCar> ReturnCars { get; set; }
    }
}
