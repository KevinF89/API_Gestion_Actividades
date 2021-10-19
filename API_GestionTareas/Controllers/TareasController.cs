using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_GestionTareas.Models;
using API_GestionTareas.Models.Otros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness.Logic;
using Data.Models;

namespace API_GestionTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TareasController : ControllerBase
    {
        /// <summary>
        /// Get a list with all the user tasks
        /// </summary>
        /// <param name="IdUsuario">user id</param>
        /// <returns>A tasks list</returns>
        //[Route("~/api/ConsTareasEmpleado")]
        //[HttpGet]
        //public RespuestaGestion ConsTareasEmpleado(int IdUsuario)
        //{
        //    RespuestaGestion Respuesta = new RespuestaGestion();
        //   // var context = new GestionContext();
        //    List<SP_ConsultarTareas_Result2> Tareas;
        //    try
        //    {
        //        object[] parameters = new[] { IdUsuario.ToString() };
        //        Tareas = context.Consultar_Tareas.FromSql("[dbo].[SP_ConsultarTareas] @p0", parameters: parameters).ToList();

        //        if (Tareas.Count > 0)
        //        {
        //            Respuesta.Valido = true;
        //            Respuesta.Tareas = Tareas;
        //        }
        //        else {
        //            Respuesta.Valido = true;
        //            Respuesta.Descripcion = "Este Empleado no tiene tareas";
        //        }
        //    }
        //    catch (Exception ex) {

        //        Respuesta.Valido = false;
        //        Respuesta.Error = ex.Message;
        //    }
        //    return Respuesta;
        //}

        [HttpGet]
        public ActionResult<RespuestaGestion> Get([FromQuery] TareasFilter filter)
        {
            RespuestaGestion Respuesta = new RespuestaGestion();
            TareasService tareasService = new TareasService();
            List<SP_ConsultarTareas_Result> Tareas;
            try
            {

                Tareas = tareasService.ConsTareasEmpleado(IdUsuario: filter.IdEmpleado, IdTarea: filter.IdActividad);

                if (Tareas.Count > 0)
                {
                    Respuesta.Valido = true;
                    Respuesta.Tareas = Tareas;
                }
                else
                {
                    Respuesta.Valido = true;
                    Respuesta.Descripcion = "Este Empleado no tiene tareas";
                }
            }
            catch (Exception ex)
            {

                Respuesta.Valido = false;
                Respuesta.Error = ex.Message;
            }
            return Respuesta;
        }
    }
}