using System.ComponentModel.DataAnnotations;

namespace Avance_1.Models
{
    public class Roles
    {
        [Key]
        [MaxLength(5), MinLength(5)] public required string IdRol { get; set; }
        [MaxLength(20)] public required string Nombre_rol { get; set; }
        [MaxLength(50)] public required string Description { get; set; }
        [MaxLength(5)] public required string Nivel_privilegio { get; set; }

    }
}
