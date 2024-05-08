using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avance_1.Models
{
    public class Siniestro
    {
        [Key]
        public required int IdSiniestro { get; set; }
        public required DateTime FechaSiniestro { get; set; }
        public required string NivelUrgencia { get; set; }
        public required string Descripcion { get; set; }

        // Foreign key relationships
        
        public required int IdZona { get; set; }  
        public Zona? Zona { get; set; }  

       
        public required int IdAgente { get; set; }
        public Agente? Agente { get; set; }
    }
}
