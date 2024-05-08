using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Avance_1.Models
{
    public class Persona
    {
        [Key]
        [MaxLength(5), MinLength(5)] public required string IdPersona { get; set; }
        [MaxLength(25)] public required string Nombres { get; set; }
        public DateOnly Fecha_nacimiento { get; set; }
        [MaxLength(10), MinLength(10)] public required int Cedula { get; set; }
    }
}
