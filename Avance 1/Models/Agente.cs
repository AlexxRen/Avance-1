using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class Agente
    {
        [Key]
        public required int IdAgente { get; set; }

        [MaxLength(15)]
        public required string Estado_Agente { get; set; }

        // Foreign key relationships

        [ForeignKey("Personaid")]
        public required int Personaid { get; set; }
        public required Persona Persona { get; set; }

        [ForeignKey("Rolid")]
        public required int Rolid { get; set; }
        public required Rol Rol { get; set; }
        

    }
}

