using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Logic
{
    public class TareasService
    {
        public List<SP_ConsultarTareas_Result> ConsTareasEmpleado(int? IdUsuario = null, int? IdTarea = null)
        {
            
            var context = new GestionContext();
            List<SP_ConsultarTareas_Result> Tareas;

                //object[] parameters = new[] { IdUsuario.ToString() };
                Tareas = context.Consultar_Tareas.FromSql("[dbo].[SP_ConsultarTareas]").ToList();
            if(IdUsuario.HasValue)
            {
                Tareas = Tareas.Where(x => x.IdEmpleado == IdUsuario.Value).ToList();
            }

            if(IdTarea.HasValue)
            {
                Tareas = Tareas.Where(x => x.IdActividad == IdTarea).ToList();
            }


            return Tareas;
        }
    }
}
