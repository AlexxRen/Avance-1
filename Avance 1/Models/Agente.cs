using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class Agente
    {

        [Key]
        [MaxLength(5), MinLength(5)]
        public required string IdAgente { get; set; }

        [MaxLength(15)] 
        public required string Cargo { get; set; }

        // Foreign key 
        public required Persona Persona { get; set; }
        [ForeignKey("PersonaId")] 
        public required string PersonaId { get; set; }

        public required Roles Rol { get; set; }
        [ForeignKey("RolId")] 
        public required string RolId { get; set; }


    }
}
