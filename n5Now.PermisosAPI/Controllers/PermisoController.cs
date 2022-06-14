#region Documentación
/* Descripción: Controlador de la entidad Permisos
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
    /// Controlador de la entidad Permisos
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        #region Variables
        private readonly IPermiso permiso;
        #endregion

        #region  Constructor
        public PermisoController(IPermiso ipermiso)
        {
            this.permiso = ipermiso;
        }
        #endregion


        #region Médotos WEB API
        /// <summary>
        /// Método POST para agregar un elemento al catálogo de Permisos
        /// </summary>
        /// <param name="permiso_model">Objeto tipado como JSON para el procesamiento de la solicitud </param>
        /// <returns>Devuelve dos estados; un 200 y un 400, depende de la respuesta que nos regresa la clase Service</returns>
        [HttpPost("add")]
        public ActionResult<Dictionary<string, object>> RequestPermission([FromBody] PermisoViewModel permiso_model)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (!ModelState.IsValid) throw new Exception(new String("¡No se puede procesar la solicitud!"));

                var _objPermiso = this.permiso.AgregarPermiso(permiso_model);
                result.Add("success", true);
                result.Add("data", _objPermiso);
                result.Add("msg", new String("¡Permiso agendado correctamente!"));
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

        /// <summary>
        /// Método PUT para modificar un elemento de nuestro catálogo Permiso
        /// </summary>
        /// <param name="permisoModel">Objeto con las características del modelo Permiso</param>
        /// <returns>Devuelve dos estados; un 200 y un 400, depende de la respuesta que nos regresa la clase Service</returns>
        [HttpPut("modify")]
        public ActionResult<Dictionary<string, object>> ModifyPermission([FromBody] PermisoViewModel permisoModel)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (!ModelState.IsValid) throw new Exception(new String("¡No se puede procesar la solicitud!"));


                var objPermiso = this.permiso.EditarPermiso(permisoModel);

                result.Add("success", true);
                result.Add("data", objPermiso);
                result.Add("msg", new String("¡Permiso modificado con éxito!"));
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

        /// <summary>
        /// Método GET para obtener la información de un elemento del catálogo Permiso a través de un ID de búsqueda
        /// </summary>
        /// <param name="id">ID del catálogo que se requiere buscar</param>
        /// <returns>Devuelve dos estados; un 200 y un 400, depende de la respuesta que nos regresa la clase Service</returns>
        [HttpGet("get/{id}")]
        [Route("{id:int}")]
        public ActionResult<Dictionary<string, object>> GetPermission(int id)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                var listPermisos = this.permiso.ObtenerPermiso(id);

                if (listPermisos.Count == 0) throw new Exception(new String("Sin información para mostrar"));
                result.Add("success", true);
                result.Add("data", listPermisos);
                result.Add("msg", new String("¡Solicitud procesada correctamente"));

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

        /// <summary>
        /// Método GET que devuelve todos los elementos del catálogo Permiso
        /// </summary>
        /// <returns>Devuelve dos estados; un 200 y un 400, depende de la respuesta que nos regresa la clase Service</returns>
        [HttpGet("getAll")]
        public ActionResult<Dictionary<string, object>> GetAllPermission()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                var listPermisos = this.permiso.ObtenerPermisosTodos();

                if (listPermisos.Count == 0) throw new Exception(new String("Sin información para mostrar"));
                result.Add("success", true);
                result.Add("data", listPermisos);
                result.Add("msg", new String("¡Solicitud procesada correctamente"));

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
