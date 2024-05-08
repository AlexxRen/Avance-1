using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class Siniestro
    {
        [Key,MinLength(5),MaxLength(5)]public required string IdSiniestro { get; set; }
        public required DateTime Fecha_Siniestro { get; set; }
       [MinLength(5), MaxLength(5)] public required string Nivel_Siniestro { get; set; }
        public char IdCam {  get; set; }
        public required CamECU911 Camdesignada { get; set; }
        public required string IdAgente { get; set; } 
        public required Agente Agente_designado { get; set; }
    }
}
