namespace DBTheRideYouRentTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [StringLength(8)]
        public string CarNo { get; set; }

        [Required]
        [StringLength(25)]
        public string Car_Make { get; set; }

        [StringLength(30)]
        public string Model { get; set; }

        [StringLength(15)]
        public string BodyType { get; set; }

        public int? Kilometres_Travelled { get; set; }

        public int? Service_kilometres { get; set; }

        [Required]
        [StringLength(4)]
        public string Avaliable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
