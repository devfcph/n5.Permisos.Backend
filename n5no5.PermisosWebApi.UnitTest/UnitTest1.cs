using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using n5Now.PermisosAPI.DataContext;
    using n5Now.PermisosAPI.Models;
using n5Now.PermisosAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace n5no5.PermisosWebApi.UnitTest
{
    public class UnitTest1
    {

        public DbContextOptionsBuilder<n5Now.PermisosAPI.DataContext.AppDatabaseContext> OptionsBuilder { get; set; }

        public UnitTest1()
        {
            OptionsBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            OptionsBuilder.UseSqlServer("Server=ACERNITRO5-CRIS\\SQLEXPRESS;Database=n5_core_securityDB;User Id=sa;Password=admin;");
        }
        [Fact]
        public void testRequestPermission()
        {
            bool respuesta = false;
            Permiso model = new Permiso()
            {
                IdPermisos = 0,
                NombreEmpleado = "TEST DESDE PRUEBAS UNITARIAS",
                ApellidoEmpleado = "TEST TEST",
                IdTipoPermiso = 1,
                FechaPermiso = DateTime.Now,
            };


            using (var context = new AppDatabaseContext(OptionsBuilder.Options))
            {

                context.Permisos.Add(model);
                var efDefaultId = model.IdPermisos;
                respuesta = context.SaveChanges() > 0 ? true : false;

            }

            //Obtener el resultado que se guardo success

            Assert.True(respuesta);
        }

        [Fact]
        public void testModifyPermission()
        {
            bool respuesta = false;
            Permiso model = new Permiso()
            {
                IdPermisos = 1,
                NombreEmpleado = "TEST DESDE PRUEBAS UNITARIAS",
                ApellidoEmpleado = "TEST TEST",
                IdTipoPermiso = 2,
                FechaPermiso = DateTime.Now,
            };


            using (var context = new AppDatabaseContext(OptionsBuilder.Options))
            {

                context.Permisos.Update(model);
                var efDefaultId = model.IdPermisos;
                respuesta = context.SaveChanges() > 0 ? true : false;

            }

            //Obtener el resultado que se guardo success

            Assert.True(respuesta);
        }

        [Fact]
        public void testGetPermission()
        {
            bool respuesta = false;
            List<n5Now.PermisosAPI.Models.ViewModels.PermisoViewModel> lstPermisos = new List<n5Now.PermisosAPI.Models.ViewModels.PermisoViewModel>();

            using (var context = new AppDatabaseContext(OptionsBuilder.Options))
            {

                var result = context.PermisosViewModel.FromSqlInterpolated($"EXECUTE dbo._sp_Permisos_Obtener @idPermiso = DEFAULT;").ToList();

                respuesta = result.Count > 0 ? true : false;

            }

            //Obtener el resultado que se guardo success

            Assert.True(respuesta);
        }
    }
}
