using System.ComponentModel;

namespace ProyectoSeguridad.Models
{
    public class Amenaza
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Nombre Amenaza")]
        public string nombreAmenaza { get; set; }
        [DisplayName("Descripción Amenaza")]
        public string descripcionAmenaza { get; set; }
        [DisplayName("Probabilidad que ataque (1-10)")]
        public int valor { get; set; }
    }
}
