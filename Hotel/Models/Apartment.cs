using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Type")]
        public int ApTypeId { get; set; }
        public ApType Type { get; set; }
    }
}