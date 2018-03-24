using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class ApType
    {
        [Key]
        public int TypeId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int NumOfPerson { get; set; }
    }
}