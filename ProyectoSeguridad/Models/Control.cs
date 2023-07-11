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
        [DisplayName("Nivel de Efectividad")]
        public string efectividad { get; set; }

        // Clave foránea
        public int ActivoId { get; set; }
    }

}