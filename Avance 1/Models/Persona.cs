using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Avance_1.Models
{
    public class Persona
    {
        [Key]
        public required int IdPersona { get; set; }

        [MaxLength(25)]
        public required string Nombres { get; set; }

        public DateOnly Fecha_nacimiento { get; set; }

        [MaxLength(10), MinLength(10)]public required string Cedula { get; set; }
    }

}
