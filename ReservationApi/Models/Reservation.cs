using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationApi.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }
         public int IdClient { get; set; }
        public virtual Client client { get; set; }
        public int IdTerrain { get; set; }
        public virtual Terrain terrain { get; set; }
        [Range(0, 22)]
        public int NbPlace_Reserve { get; set; }

    }
}
