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
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReservationStatus Status { get; set; }
        public string Name { get; set; }
        public string Suname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal ReservationPrie { get; set; }

        public Apartment Apartment { get; set; }
    }
}