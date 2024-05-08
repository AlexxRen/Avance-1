using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class Siniestro
    {
        [Key]
        public required string IdSiniestro { get; set; }
        public required string IdZona { get; set; }
        public required DateTime FechaSiniestro { get; set; }
        public required string NivelUrgencia { get; set; }
        public required string Descripcion { get; set; }
        public required string IdAgente { get; set; }

        // Foreign key relationships (assuming you have similar models for other tables)
        public required Zona Zona { get; set; }
        public required Agente Agente { get; set; }
    }

}
