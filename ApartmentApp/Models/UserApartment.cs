using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ApartmentApp.Models
{
    public class UserApartment
    {
        public int UserApartmentID { get; set; }
        public int UserID { get; set; }
        public int ApartmentID { get; set; }
        [DefaultValue(false)]
        public Boolean Owner { get; set; }
        [DefaultValue(true)]
        public Boolean Resident { get; set; }

        public User User { get; set; }
        public Apartment Apartment { get; set; }
    }
}