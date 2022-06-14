#region Documentación
/* Descripción: Modelo de la entidad TipoPermiso
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion

#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#endregion

namespace n5Now.PermisosAPI.Models.Enums
{
    [Table("TipoPermisos")]
    public class TipoPermiso
    {
        #region Atributos de la entidad TipoPermiso
        /// <summary>
        /// Identificador de la entidad TipoPermiso
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoPermiso { get; set; }

        /// <summary>
        /// Descripción de la entidad TipoPermiso, hace referencia a la columna descripcion
        /// </summary>
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 1, ErrorMessage = "Tipo de permiso no válido")]
        public string Descripcion { get; set; }
        #endregion
    }
}
