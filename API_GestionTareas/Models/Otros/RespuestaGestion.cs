using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_GestionTareas.Models.Otros
{
    public class RespuestaGestion
    {
        [DataMember]
        public bool Valido { get; set; }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

        public List<SP_ConsultarTareas_Result> Tareas { get; set; }
    }
}
