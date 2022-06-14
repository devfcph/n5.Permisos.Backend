#region Documentación
/* Descripción: Clase ViewModel para traer la información de los permisos, con su respectivo tipo de permiso.
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion


namespace n5Now.PermisosAPI.Models.ViewModels
{
    /// <summary>
    /// Clase PermisoViewModel que hace referencia a la unión de las entidades Permiso y TipoPermiso
    /// </summary>
    public class PermisoViewModel
    {

        #region Atributos de la Unión de las Entidades Permiso y TipoPermiso
        /// <summary>
        /// ID de la tabla Permiso
        /// </summary>
        [Key]
        public int idPermiso { get; set; }

        /// <summary>
        /// Nombre del empleado, proviene de la entidad Permisos
        /// </summary>
        public string nombreEmpleado { get; set; }

        /// <summary>
        /// Apellido del Empleado, proviene de la entidad Permiso
        /// </summary>
        public string apellidoEmpleado { get; set; }

        /// <summary>
        /// Nombre Completo del Empleado, proviene de la concatenación de los campos nombre y apellido de la entidad Permiso
        /// </summary>
        public string nombreCompletoEmpleado { get; set; }

        /// <summary>
        /// Fecha del permiso, proviene de la entidad Permiso
        /// </summary>
        public DateTime fechaPermiso { get; set; }

        /// <summary>
        /// ID del catálogo TipoPermiso
        /// </summary>
        public int idTipoPermiso { get; set; }

        /// <summary>
        /// Descripción del catálogo TipoPermiso
        /// </summary>
        public string descripcionTipoPermiso { get; set; }
        #endregion

    }
}
