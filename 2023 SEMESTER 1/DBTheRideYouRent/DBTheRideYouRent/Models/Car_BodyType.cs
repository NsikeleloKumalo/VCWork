namespace DBTheRideYouRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car_BodyType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Car_BodyTypeID { get; set; }

        [StringLength(255)]
        public string BodyType_Description { get; set; }
    }
}
