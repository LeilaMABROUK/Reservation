using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationApi.Models
{
    public class Club
    {
        [Key]
        public int IdClub { get; set; }
        [Required]
        public string NameClub { get; set; }
        [Required]
        public string Address { get; set; }
        public int Tel { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.DateTime)]

        public DateTime Heure_Ouverture { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Heure_Fermeture { get; set; }
        public virtual ICollection<Terrain> Terrains { get; set; }

    }
}
