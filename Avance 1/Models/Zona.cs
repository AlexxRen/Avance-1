using System.ComponentModel.DataAnnotations;

namespace Avance_1.Models
{
    public class Zona
    {
        [Key]
        public required int IdZona { get; set; }
        
        [MaxLength(20)] 
        public required string Descripcion_zona { get; set; }

    }
}
