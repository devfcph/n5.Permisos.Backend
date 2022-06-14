#region Documentación
/* Descripción: Interface Permiso que contiene los métodos a implementar en la clase PermisoService
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using Microsoft.AspNetCore.Mvc;
using n5Now.PermisosAPI.Models.Entities;
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
    /// Interface que contiene los métodos a ímplementar para el modelo Permiso
    /// </summary>
    public interface IPermiso
    {
        #region Métodos CRUD
        /// <summary>
        /// Método para agregar un elemento al cátalogo Permiso
        /// </summary>
        /// <param name="permiso"> Objeto de tipo PermisoViewModel</param>
        /// <returns>Regresa un objeto de tipo PermisoViewModel con la información insertada </returns>
        public PermisoViewModel AgregarPermiso(PermisoViewModel permiso);

        /// <summary>
        /// Método para modificar los datos de un permiso
        /// </summary>
        /// <param name="permiso">Obejto de ipo PermisoViewModel</param>
        /// <returns>Regresa un objeto del modelo PermisoViewModel, con la información actualizada</returns>
        public PermisoViewModel EditarPermiso(PermisoViewModel permiso);

        /// <summary>
        /// Elimina un elemento del catálogo 
        /// </summary>
        /// <param name="idPermiso">ID del catálogo Permiso</param>
        /// <returns>Devuelve un objeto tipo Diccionario, el cuál tiene como Key un string y como value un bool </returns>
        public Dictionary<bool, string> EliminarPermiso(int idPermiso);

        /// <summary>
        /// Regresa un objeto de tipo Permiso
        /// </summary>
        /// <param name="idPermiso">ID a buscar del catálogo Permiso</param>
        /// <returns>Regresa una lista de objetos, por lo general, siempre regresará un elemento </returns>
        public List<PermisoViewModel>  ObtenerPermiso(int idPermiso);

        /// <summary>
        /// Devuelve todos los permisos del catálogo Permiso
        /// </summary>
        /// <returns>Retrona una lista de objetos de tipo PermisoViewModel</returns>
        public List<PermisoViewModel> ObtenerPermisosTodos();
        #endregion|
    }
}
