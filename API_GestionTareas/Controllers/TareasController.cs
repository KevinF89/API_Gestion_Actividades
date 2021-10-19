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
    [Authorize]
    public class TareasController : ControllerBase
    {
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