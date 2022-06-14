#region Documentación
/* Descripción: Controlador de la entidad TipoPermiso
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using n5Now.PermisosAPI.ApiBusiness.Interfaces;
using n5Now.PermisosAPI.Models.ViewModels;
#endregion



namespace n5Now.PermisosAPI.Controllers
{
    /// <summary>
    /// Controlador del modelo TipoPermiso
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class TipoPermisoController : ControllerBase
    {
        #region Variables
        private ITipoPermiso tipoPermiso;
        #endregion

        #region Constructor
        public TipoPermisoController(ITipoPermiso _ItipoPermiso)
        {
            this.tipoPermiso = _ItipoPermiso;
        }
        #endregion

        #region Métodos del Constructor
        /// <summary>
        /// Método del controlador que retorna los elementos de la entidad TipoPermiso
        /// </summary>
        /// <returns>Devuelve dos estados; un 200 y un 400, depende de la respuesta que nos regresa la clase Servicereturns>
        [HttpGet("getAll")]
        public ActionResult<Dictionary<string, object>> GetTipoPermisos()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                var response = this.tipoPermiso.ObtenerTiposPermisos();
                result.Add("success", true);
                result.Add("data", response);
                result.Add("msg", new String("¡Solicitud procesada correctamente!"));
                return Ok(result);
            }
            catch (Exception e)
            {
                result.Add("success", false);
                result.Add("data", null);
                result.Add("msg", e.Message);
                return BadRequest(result);
            }
        }
        #endregion
    }
}
