using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApp.Models
{
    public class Apartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApartmentID { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public Boolean Garage { get; set; }
        public int Shares { get; set; }

        public ICollection<UserApartment> UsersApartments { get; set; }
    }
}