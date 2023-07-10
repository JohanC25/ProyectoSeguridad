using System.ComponentModel;

namespace ProyectoSeguridad.Models
{
    public class Vulnerabilidad
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Nombre Vulnerabilidad")]
        public string nombreVulnerabilidad { get; set; }
        [DisplayName("Descripción Vulnerabilidad")]
        public string descripcionVulnerabilidad { get; set; }
        [DisplayName("CVSS")]
        public decimal cvss { get; set; }
    }
}
