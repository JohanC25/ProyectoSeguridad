using System.ComponentModel;

namespace ProyectoSeguridad.Models
{
    public class Activo
    {
        [DisplayName("Código Interno")]
        public int id { get; set; }
        [DisplayName("Nombre Activo")]
        public string nombre { get; set; }
        [DisplayName("Categoria Activo")]
        public string categoria { get; set; }
        [DisplayName("Departamento")]
        public string departamento { get; set; }
        [DisplayName("Costo Activo")]
        public decimal costoActivo { get; set; }
        [DisplayName("Confidencialidad Activo")]
        public string confidencialidad { get; set; }
        [DisplayName("Integridad Activo")]
        public string integridad { get; set; }
        [DisplayName("Disponibilidad Activo")]
        public string disponibilidad { get; set; }
        [DisplayName("Clasificación Confidencialidad")]
        public string clas_conf { get; set; }
        [DisplayName("Clasificación Integridad")]
        public string clas_int { get; set; }
        [DisplayName("Clasificación Disponibilidad")]
        public string clas_disp { get; set; }
        [DisplayName("Valor Activo")]
        public int valor { get; set; }

        public static List<string> Categorias { get; set; } = new List<string> { "Software", "Hardware" };

        public Activo()
        {
            categoria = Categorias[0];
        }
    }

    public enum Riesgo
    {
        Alto = 3,
        Medio = 2,
        Bajo = 1
    }

}
