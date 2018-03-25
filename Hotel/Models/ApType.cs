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
        [Required]
        [Display(Name = "Тип")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Вартість")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Кількість місць")]
        public int NumOfPerson { get; set; }
    }
}