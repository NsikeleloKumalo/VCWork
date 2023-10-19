namespace DBTheRideYouRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReturnCar")]
    public partial class ReturnCar
    {
        [Key]
        [StringLength(6)]
        public string Return_id { get; set; }

        [Required]
        [StringLength(6)]
        public string Rental_no { get; set; }

        [Required]
        [StringLength(6)]
        public string Inspector_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }

        public int ElapsedDate { get; set; }

        public double? Fine { get; set; }

        public virtual Inspector Inspector { get; set; }

        public virtual Rental Rental { get; set; }
    }
}
