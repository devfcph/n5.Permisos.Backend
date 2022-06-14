#region Documentación
/* Descripción: Modelo de la entidad Permiso
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion


namespace n5Now.PermisosAPI.Models.Entities
{
    /// <summary>
    /// Modelo que hace referencia a la tabla Permisos
    /// </summary>
    [Table("Permisos")]
    public class Permiso
    {
        #region Atributos de la entidad Permiso
        /// <summary>
        /// Hace referencia a la columna del identificador de la tabla, con los atributos de llave primaria y autoincrementable
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermisos { get; set; }

        /// <summary>
        /// Requerido: Nombre del empleado, hace referencia a la columna nombreEmpleado de la tabla Permisos
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "¡El nombre no es válido!")]
        public string NombreEmpleado { get; set; }

        /// <summary>
        /// Requerido: Apellido del empleado, hace referencia a la columna apellidoEmpleado de la tabla Permisos
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "¡Apellido no válido!")]
        public string ApellidoEmpleado { get; set; }

        /// <summary>
        /// Hace referencia a la llave foránea con la entidad TipoPermiso
        /// </summary>
        [ForeignKey("FK_Permiso_TipoPermiso")]
        public int IdTipoPermiso { get; set; }

        /// <summary>
        /// Requerido: Fecha del permiso, hace referencia a la columna fechaPermiso
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPermiso { get; set; }

        /// <summary>
        /// Fecha de creación, por default ya lleva la fecha y hora actual
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Fecha de Modificación, por default ya lleva la fecha y hora actual
        /// </summary>
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        #endregion
    }
}
