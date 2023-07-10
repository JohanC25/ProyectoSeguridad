using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoSeguridad.Models;

namespace ProyectoSeguridad.Data
{
    public class ProyectoSeguridadContext : DbContext
    {
        public ProyectoSeguridadContext (DbContextOptions<ProyectoSeguridadContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoSeguridad.Models.Activo> Activo { get; set; } = default!;

        public DbSet<ProyectoSeguridad.Models.Amenaza>? Amenaza { get; set; }

        public DbSet<ProyectoSeguridad.Models.Vulnerabilidad>? Vulnerabilidad { get; set; }
    }
}
