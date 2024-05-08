using System.ComponentModel.DataAnnotations;

namespace Avance_1.Models
{
    public class Rol
    {
        [Key]
        public required int IdRol { get; set; }
        [MaxLength(20)] public required string Nombre_rol { get; set; }
        [MaxLength(50)] public required string Description { get; set; }
        [MaxLength(5)]public required string Tipo_privilegio { get; set; }

    }
}
