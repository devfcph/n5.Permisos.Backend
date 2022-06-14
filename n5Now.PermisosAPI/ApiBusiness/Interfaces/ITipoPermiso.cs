#region Documentación
/* Descripción: Interface TipoPermiso que contiene los métodos a implementar en la clase TipoPermisoService
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using Microsoft.AspNetCore.Mvc;
using n5Now.PermisosAPI.Models.Entities;
using n5Now.PermisosAPI.Models.Enums;
using n5Now.PermisosAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion
namespace n5Now.PermisosAPI.ApiBusiness.Interfaces
{
    /// <summary>
    /// Interface que contiene los métodos a implementar de la entidad TipoPermiso, dentro de la clase TipoPermisoService
    /// </summary>
    public interface ITipoPermiso
    {
        /// <summary>
        /// Método que retornará una lista de elementos de la entidad TipoPermiso
        /// </summary>
        /// <returns>Regresa una lista de objetos de tipo TipoPermiso</returns>
        public List<TipoPermiso> ObtenerTiposPermisos();
    }
}
