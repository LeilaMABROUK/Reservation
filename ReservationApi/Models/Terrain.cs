using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationApi.Models
{
    public enum Type { FootBall, BasketBall, Tennis };
public class Terrain
    {
        [Key]
        public int IdTerrain { get; set; }
        [Required]
        public string nameTerrain { get; set; }
       
        [Range(0, 22)]
        public int Nb_place { get; set; }

        public Type type { get; set; }
        [ForeignKey("IdClub ")]
        public int IdClub { get; set; }
        public virtual Club club { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

             
    }
}
