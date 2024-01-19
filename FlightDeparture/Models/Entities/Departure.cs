using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightDeparture.Models.Entities
{
    public class Departure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Departure")]
        public DateTime DepartureWhen { get; set; }

        [Required, DisplayName("Flight"), MaxLength(64)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Gate { get; set; }

        [Required, MaxLength(64)]
        public string Aircraft { get; set; } = string.Empty;

        [Required, MaxLength(64)]
        public string Destination { get; set; } = string.Empty;
    }
}
