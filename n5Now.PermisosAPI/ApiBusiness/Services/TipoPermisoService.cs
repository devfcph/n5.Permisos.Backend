#region Documentación
/* Descripción: Clase TipoPermisoService, aquí se implementa la lógica de negocios del catálogo TipoPermiso
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using Microsoft.AspNetCore.Mvc;
using n5Now.PermisosAPI.ApiBusiness.Interfaces;
using n5Now.PermisosAPI.DataContext;
using n5Now.PermisosAPI.Models.Entities;
using n5Now.PermisosAPI.Models.ViewModels;
using n5Now.PermisosAPI.Models.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
#endregion



namespace n5Now.PermisosAPI.ApiBusiness.Services
{
    /// <summary>
    /// Clase TipoPermisoService, la cual implementa la interface ITipoPermiso
    /// </summary>
    public class TipoPermisoService : ITipoPermiso
    {
        #region Variables
        private readonly AppDatabaseContext _appDatabaseContext;
        #endregion

        #region Construtor
        /// <summary>
        /// Constructor de la clase TipoPermisoService
        /// </summary>
        /// <param name="context">Objeto de la clase AppDatabaseContext</param>
        public TipoPermisoService(AppDatabaseContext context)
        {
            this._appDatabaseContext = context;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método que obtiene los elementos del catálogo TipoPermisos
        /// </summary>
        /// <returns>Retorna una lista de elementos de la entidad TipoPermiso</returns>
        /// <exception cref="NotImplementedException">Las excepciones que se presenten, serán identifacadas en el controlador como BAD_REQUEST </exception>
        public List<TipoPermiso> ObtenerTiposPermisos()
        {
            try
            {
                List<TipoPermiso> listaTipoPermiso = this._appDatabaseContext.TipoPermisos.FromSqlInterpolated($"EXECUTE dbo._sp_TipoPermisos_Obtener").ToList();
                return listaTipoPermiso;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
