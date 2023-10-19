namespace TheRideYouRentFinalTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car_Make
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Car_MakeID { get; set; }

        [StringLength(255)]
        public string Make_Description { get; set; }
    }
}
