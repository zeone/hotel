using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Hotel.Enums;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [Required]
        [Display(Name = "Назва номеру")]
        public int ApartmentId { get; set; }
        [Required]
        [Display(Name = "Дата заїзду")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Дата виїзду")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Статус")]
        public ReservationStatus Status { get; set; }
        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамілія")]
        public string Suname { get; set; }
        [Required]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Вартість на момент резервування")]
        public decimal ReservationPriсe { get; set; }
        public Apartment Apartment { get; set; }
    }
}