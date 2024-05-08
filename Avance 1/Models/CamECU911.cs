using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class CamECU911
    {
        [Key]
        public required int IdCam { get; set; }
        [MaxLength(200)] public required string Ubicacion { get; set; }
        
        [ForeignKey("IdZona")]
        public required int IdZona { get; set; }
        public Zona? Zona { get; set; }  

    }
}
