﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TheRideYouRentPOE.Models
{
    public partial class Inspector
    {
        public Inspector()
        {
            Rental = new HashSet<Rental>();
            ReturnCar = new HashSet<ReturnCar>();
        }

        public string InspectorNo { get; set; }
        public string InspectorName { get; set; }
        public string InspectorEmail { get; set; }
        public string InspectorMobile { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
        public virtual ICollection<ReturnCar> ReturnCar { get; set; }
    }
}