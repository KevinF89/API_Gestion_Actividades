using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SP_ConsultarTareas_Result
    {
        [Key]
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public DateTime FechaProyectada { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdEmpleado { get; set; }
        public string Descripcion { get; set; }
    }
}
