using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias
{
    [TestClass]
    public class RegistroUsuario
    {
        Persona admin;
        Persona persona;

        [TestInitialize]
        public void TestInitialize()
        {
            admin = new Persona
            {
                Usuario = "admin1",
                Email = "admin1@gmail.com",
                Password = "admin1",
                IdTipoUsuario = 3,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 1,
                Telefono = "admin1",
                Direccion = "admin1",
                Estatus = 1,
                Comercio = false,
                Nombre = "admin1",
                Apellido = "admin1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "admin1",
            };

            persona = new Persona
            {
                Usuario = "testUser12",
                Email = "testUser12@gmail.com",
                Password = "testUser12",
                IdTipoUsuario = 1,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 12,
                Telefono = "testUser1",
                Direccion = "testUser1",
                Estatus = 1,
                Comercio = false,
                Nombre = "testUser1",
                Apellido = "testUser1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "testUser1",
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [TestMethod]
        public void registro_usuario()
        {
            Task<HttpResponseMessage> res = APITest.register(persona);
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
            APITest.EliminarUsuario(1);
        }

        /*[TestMethod]
        public void registro_usuario_validarUsuarioRepetidoXUsuario()
        {
            Task.Run(async () =>
            {

                HttpResponseMessage res = await APITest.register(persona);
                Assert.IsTrue(res.StatusCode == HttpStatusCode.BadRequest);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void registro_usuario_validarUsuarioRepetidoXCorreo()
        {
            Task.Run(async () =>
            {
                persona.Usuario = "user" 
                HttpResponseMessage res = await APITest.register(persona);
                Assert.IsTrue(res.StatusCode == HttpStatusCode.BadRequest);
            }).GetAwaiter().GetResult();
        }*/

    }
}
