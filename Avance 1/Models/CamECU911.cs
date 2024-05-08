using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class CamECU911
    {
        [MinLength(5), MaxLength(5),Key] public required string IdCam { get; set; }
        [MaxLength(200)] public required string Ubicacion { get; set; }

        [ForeignKey("IdCam")]
        [MinLength(5), MaxLength(5)] public required string IdZona { get; set; }
        public required Zona Zona_designada { get; set; }  

    }
}
