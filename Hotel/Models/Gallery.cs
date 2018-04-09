using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Gallery
    {
        [Key]
        public int ImgId { get; set; }
        public string ImgName { get; set; }
    }
}