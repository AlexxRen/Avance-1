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
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "La cédula debe contener solo 10 números.")] public required string Cedula { get; set; }
    }
}
