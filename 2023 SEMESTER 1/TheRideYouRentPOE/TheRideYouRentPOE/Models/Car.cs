﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TheRideYouRentPOE.Models
{
    public partial class Car
    {
        public Car()
        {
            Rental = new HashSet<Rental>();
        }

        public string CarNo { get; set; }
        public string CarMake { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public int? KilometresTravelled { get; set; }
        public int? ServiceKilometres { get; set; }
        public string Avaliable { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}