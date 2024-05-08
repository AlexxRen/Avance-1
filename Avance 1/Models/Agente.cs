using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_1.Models
{
    public class Agente
    {

        [Key]
        [MaxLength(5), MinLength(5)] public required string IdAgente { get; set; }
        [MaxLength(50)] public required string Descripcion { get; set; }

        [ForeignKey ("IdAgente")]
        [MaxLength(5), MinLength(5)] public required string IdPersona { get; set; }    
        public required Persona Designio { get; set; }
        [MaxLength(5), MinLength(5)] public required string idRole { get; set; }
        public required Roles rol { get; set; }
        

    }
}
