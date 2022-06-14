#region Documentación
/* Descripción: Clase PermisoService, aquí se implementa la lógica de negocios del catálogo Permiso
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
    /// Clase PermisoService, implementa la interfaz IPermiso
    /// </summary>
    public class PermisoService : IPermiso
    {
        #region variables
        private readonly AppDatabaseContext _context;
        #endregion

        #region Constructor
        public PermisoService(AppDatabaseContext context)
        {
            this._context = context;
        }
        #endregion


        #region Métodos Service
        /// <summary>
        /// Método para agrear un permiso al catálogo Permiso
        /// </summary>
        /// <param name="permiso">Recibe un objeto de tipo PermisoViewModel</param>
        /// <returns>Regresa un objeto de tipo PermisoViewModel con la información insertada</returns>
        /// <exception cref="System.Exception">Algunas excepciones se disparán desde el Store Procedure</exception>
        public PermisoViewModel AgregarPermiso(PermisoViewModel permiso)
        {
            if (permiso == null) throw new System.Exception("¡No se puede continuar con la solicitud!");
            if (permiso.nombreEmpleado == null || permiso.nombreEmpleado == "") throw new Exception("¡El nombre es requerido!");
            if (permiso.apellidoEmpleado == null || permiso.apellidoEmpleado == "") throw new Exception("¡El apellido es requerido!");
            if (permiso.idTipoPermiso == 0) throw new Exception("¡El tipo de permiso es requerido!");
            if (permiso.fechaPermiso == null ) throw new Exception("Fecha inváida");
            try
            {
                Permiso permisoTemporal = new Permiso
                {
                    //IdPermisos = 0,
                    NombreEmpleado = permiso.nombreEmpleado,
                    ApellidoEmpleado = permiso.apellidoEmpleado,
                    FechaPermiso = permiso.fechaPermiso,
                    IdTipoPermiso = permiso.idTipoPermiso
                };

                var success = this._context.PermisosViewModel.FromSqlInterpolated($"DECLARE @success_ BIT; EXECUTE dbo._sp_Permisos_Agregar @nombreEmpleado = {permisoTemporal.NombreEmpleado}, @apellidoEmpleado = {permisoTemporal.ApellidoEmpleado}, @fechaPermiso = {permisoTemporal.FechaPermiso}, @idTipoPermiso = {permisoTemporal.IdTipoPermiso}, @success = @success_ OUTPUT;").ToList();

                if (success.Count > 0) return success[0];
                else throw new Exception("No fue posible actualizar el permiso.");

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

        }

        /// <summary>
        /// Método que permite la modificación de un elemento del catálogo de Permisos
        /// </summary>
        /// <param name="permiso">Recibe un objeto de tipo PermisoViewModel</param>
        /// <returns>Regresa un objeto de tipo PersonaViewModel, el cual contiene la información actualizada</returns>
        /// <exception cref="Exception">Algunas excepciones se disparán desde el Store Procedure</exception>
        public PermisoViewModel EditarPermiso(PermisoViewModel permiso)
        {
            if (permiso == null) throw new Exception(new String("¡No se completó la solicitud!"));
            if (permiso == null) throw new System.Exception("¡No se puede continuar con la solicitud!");
            if (permiso.nombreEmpleado == null || permiso.nombreEmpleado == "") throw new Exception("¡El nombre es requerido!");
            if (permiso.apellidoEmpleado == null || permiso.apellidoEmpleado == "") throw new Exception("¡El apellido es requerido!");
            if (permiso.idTipoPermiso == 0) throw new Exception("¡El tipo de permiso es requerido!");
            if (permiso.fechaPermiso == null ) throw new Exception("Fecha inváida");
            try
            {
                Permiso permisoTemporal = new Permiso
                {
                    IdPermisos = permiso.idPermiso,
                    NombreEmpleado = permiso.nombreEmpleado,
                    ApellidoEmpleado = permiso.apellidoEmpleado,
                    FechaPermiso = permiso.fechaPermiso,
                    FechaModificacion = DateTime.Now,
                    IdTipoPermiso = permiso.idTipoPermiso
                };


                string Query = String.Format("DECLARE @success_ BIT; EXECUTE dbo._sp_Permisos_Editar @idPermiso = {0}, @fechaPermiso = \"{1}\", @idTipoPermiso = {2}, @success = @success_ OUTPUT; SELECT @success_ as success;", permisoTemporal.IdPermisos, permisoTemporal.FechaPermiso.ToString("yyyy-MM-dd"), permisoTemporal.IdTipoPermiso);


                var success = this._context.PermisosViewModel.FromSqlInterpolated($"DECLARE @success_ BIT; EXECUTE dbo._sp_Permisos_Editar @idPermiso = {permisoTemporal.IdPermisos}, @fechaPermiso = {permisoTemporal.FechaPermiso.ToString("yyyy-MM-dd")}, @nombreEmpleado = {permisoTemporal.NombreEmpleado}, @apellidoEmpleado = {permisoTemporal.ApellidoEmpleado}, @idTipoPermiso = {permisoTemporal.IdTipoPermiso}, @success = @success_ OUTPUT; SELECT @success_ as success;").ToList();

                if (success.Count > 0) return success[0];
                else throw new Exception("No fue posible actualizar el permiso.");


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Método para elimiar un elemento del catálogo
        /// </summary>
        /// <param name="idPermiso"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Dictionary<bool, string> EliminarPermiso(int idPermiso)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Obtiene un elemento del catálogo Permiso, a través del ID
        /// </summary>
        /// <param name="idPermiso">ID a buscar</param>
        /// <returns>Regresa un objeto de tipo PermisoViewModel con la información obtenida a través del ID</returns>
        /// <exception cref="Exception">Algunas excepciones se disparán desde el Store Procedure</exception>
        public List<PermisoViewModel> ObtenerPermiso(int idPermiso)
        {
            try
            {
                var result = this._context.PermisosViewModel.FromSqlInterpolated($"EXECUTE dbo._sp_Permisos_Obtener @idPermiso = {idPermiso};").ToList();

                //this._context.Database.ExecuteSqlInterpolated($"EXECUTE dbo._sp_Permisos_Obtener @idPermiso = { idPermiso };");

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los elementos del catálogo de Permisos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo PermisoViewModel</returns>
        /// <exception cref="Exception"> Algunas excepciones se disparán desde el Store Procedure </exception>
        public List<PermisoViewModel> ObtenerPermisosTodos()
        {
            try
            {
                var result = this._context.PermisosViewModel.FromSqlInterpolated($"EXECUTE dbo._sp_Permisos_Obtener @idPermiso = DEFAULT;").ToList();

                //this._context.Database.ExecuteSqlInterpolated($"EXECUTE dbo._sp_Permisos_Obtener @idPermiso = { idPermiso };");

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
