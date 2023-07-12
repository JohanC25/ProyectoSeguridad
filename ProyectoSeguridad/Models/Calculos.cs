using System.ComponentModel;

namespace ProyectoSeguridad.Models
{
    public class Calculos
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Activo")]
        public int valorActivo { get; set; }
        [DisplayName("Vulnerabilidad")]
        public float valorVulnerabilidad { get; set; }
        [DisplayName("Amenaza")]
        public int valorAmenaza { get; set; }
        [DisplayName("Total Riesgo")]
        public float total { get; set; }

        // Clave foránea
        public int ActivoValor { get; set; }
        public int VulnerabilidadValor { get; set; }
        public int AmenazaValor { get; set; }

    }
}
