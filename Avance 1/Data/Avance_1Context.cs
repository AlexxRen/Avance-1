using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Avance_1.Models;

namespace Avance_1.Data
{
    public class Avance_1Context : DbContext
    {
        public Avance_1Context (DbContextOptions<Avance_1Context> options)
            : base(options)
        {
        }


        public DbSet<Avance_1.Models.Persona> Persona { get; set; } = default!;
        public DbSet<Avance_1.Models.Zona> Zona { get; set; } = default!;
        public DbSet<Avance_1.Models.CamECU911> CamECU911 { get; set; } = default!;
        public DbSet<Avance_1.Models.Siniestro> Siniestro { get; set; } = default!;
        public DbSet<Avance_1.Models.Rol> Rol { get; set; } = default!;
        public DbSet<Avance_1.Models.Agente> Agente { get; set; } = default!;
        
    }
}
