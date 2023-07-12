using System.ComponentModel;

namespace ProyectoSeguridad.Models
{
    public class Frecuencia
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Actividad")]
        public string actividad { get; set; }
        [DisplayName("Frecuencia")]
        public string frecuencia { get; set; }
        [DisplayName("Responsable")]
        public string responsable { get; set; }

        public static List<string> Frecuencias { get; set; } = new List<string> { "Anual", "Trimestral", "Bimestral", "Semestral", "Mensual" };
        public static List<string> Responsables { get; set; } = new List<string> { "Equipo de Seguridad", "Equipo de TI" };

        public Frecuencia()
        {
            frecuencia = Frecuencias[0];
            responsable = Responsables[0];
        }
    }
}
