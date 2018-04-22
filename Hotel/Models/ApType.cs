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
        [Display(Name = "Одномісне розміщення")]
        public decimal OnePersonPrice { get; set; }
        [Display(Name = "Двомісне розміщення")]
        public decimal TwoPersonPrice { get; set; }
        [Display(Name = "Тримісне розміщення")]
        public decimal ThreePersonPrice { get; set; }
        [Display(Name = "Чотиримісне розміщення")]
        public decimal FourPersonPrice { get; set; }
        [Required]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Кількість місць")]
        public int NumOfPerson { get; set; }
    }
}