using System.ComponentModel.DataAnnotations;

namespace Avance_1.Models
{
    public class Zona
    {
        [Key]
        [MinLength(5),MaxLength(5)]public required string IdZona { get; set; }
        [MaxLength(20)] public required string Descripcion_zona { get; set; }

    }
}
