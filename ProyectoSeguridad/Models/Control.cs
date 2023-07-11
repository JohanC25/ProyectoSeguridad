using System;
using System.ComponentModel;

namespace ProyectoSeguridad.Models
{
    public class Control
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Nombre Control")]
        public string nombreControl { get; set; }
        [DisplayName("Descripción Control")]
        public string descripcionControl { get; set; }
        [DisplayName("Activo")]
        public string nombreActivo { get; set; }
        [DisplayName("Nivel de Efectividad")]
        public string efectividad { get; set; }

        //public static List<Activo> ActivoNombres { get; set; } = new List<Activo> { };

        
        /*private List<Activo> activosList;

        public Control()
        {
            activosList = new List<Activo>();
        }

        public void AddActivos(Activo activos)
        {
            activosList.Add(activos);
        }

        public List<string> GetActivosNames()
        {
            List<string> names = new List<string>();
            foreach (Activo activos in activosList)
            {
                names.Add(activos.nombre);
            }
            return names;
        }*/
    }
}
