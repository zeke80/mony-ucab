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
        Persona persona;

        [TestInitialize]
        public void TestInitialize()
        {
            persona = new Persona
            {
                Usuario = "user1231",
                Email = "user1231@gmail.com",
                Password = "passuser1",
                IdTipoUsuario = 1,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 1231,
                Telefono = "telfuser1",
                Direccion = "diruser1",
                Estatus = 1,
                Comercio = false,
                Nombre = "nomuser1",
                Apellido = "apeuser1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "razuser1",
            };
        }

        [TestMethod]
        public void registro_usuario()
        {
            Task.Run(async () =>
            {
                HttpResponseMessage res = await APITest.register(persona);
                Assert.IsTrue(res.StatusCode == HttpStatusCode.OK);
            }).GetAwaiter().GetResult();
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
