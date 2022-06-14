#region Documentación
/* Descripción: Clase en donde se define el contexto a utilizar para el mapeo de las tablas
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using Microsoft.EntityFrameworkCore;
using n5Now.PermisosAPI.Models.Entities;
using n5Now.PermisosAPI.Models.Enums;
using n5Now.PermisosAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace n5Now.PermisosAPI.DataContext
{
    /// <summary>
    /// Clase para definir el contexto a utlizar, en este caso, SQL
    /// </summary>
    public class AppDatabaseContext : DbContext
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }
        #endregion

        #region Instancias de Entidades
        /// <summary>
        /// Para la entidad Permisos se define un contexto, el cual será utilizado en la clase PermisoSerivce
        /// </summary>
        public DbSet<Permiso> Permisos { get; set; }

        /// <summary>
        /// Para la entidad PermisosViewModel se define un contexto, el cual será utilizado en la clase PermisoSerivce
        /// </summary>
        public DbSet<PermisoViewModel> PermisosViewModel { get; set; }

        /// <summary>
        /// Contexto que hace referencia a la entidad TipoPermiso
        /// </summary>
        public DbSet<TipoPermiso> TipoPermisos { get; set; }
        #endregion
    }
}
