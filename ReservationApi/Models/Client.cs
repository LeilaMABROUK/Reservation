using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationApi.Models
{
    public class Client
    {
        [Key]
         public int IdClient { get; set; }
        [Required]
        public string NameClient { get; set; }
        [Required]
        public string PrenomClient { get; set; }
        [Required]
        public int tel{ get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public virtual ICollection <Reservation> Reservations { get; set; }


    }
}
