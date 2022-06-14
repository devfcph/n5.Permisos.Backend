#region Documentación
/* Descripción: Clase principal para configurar todas las inyecciones de dependencia
 * Autor: Francisco Pérez
 * Fecha de creación: 09-06-2022
 * **/
#endregion


#region Usings
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using n5Now.PermisosAPI.ApiBusiness.Services;
using n5Now.PermisosAPI.ApiBusiness.Interfaces;
#endregion



namespace n5Now.PermisosAPI
{
    /// <summary>
    /// Clase principal para configurar todas las inyecciones de dependencia
    /// </summary>
    public static class ConfigInjection
    {
        #region Variables
        public static IContainer AplicattionContainer;
        #endregion

        #region Métodos
        /// <summary>
        /// Método principal en donde se configuran las inyecciones de dependencia
        /// </summary>
        /// <param name="services">IServicesCollection</param>
        /// <returns></returns>
        public static IContainer InjectInstances(IServiceCollection services)
        {
            var builder = new Autofac.ContainerBuilder();

            /**
             * Dependencia que hace referencia a la entidad Permiso
             */
            builder.RegisterType<PermisoService>().As<IPermiso>().InstancePerDependency();

            // Dependencia que hace referencia a la entidad TipoPermiso
            builder.RegisterType<TipoPermisoService>().As<ITipoPermiso>().InstancePerDependency();

            builder.Populate(services);
            return AplicattionContainer = builder.Build();
        }
        #endregion
    }
}
