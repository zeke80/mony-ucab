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
    public class RegistrodeUsuario
    {

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void registrodeUsuario()
        {
            dynamic infoUsuario = new
            {
                usuario = "TestUser3",
                email = "testuser3@gmail.com",
                password = "PassTestUser3",
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro =2000,
                mesRegistro =1,
                diaRegistro =1,
                nroIdentificacion = 3,
                telefono = "",
                direccion = "",
                estatus = 1,
                comercio = false,
                nombre = "",
                apellido = "",
                anoNacimiento = 2000,
                mesNacimiento = 1,
                diaNacimiento = 1,
                razonSocial = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.register(infoUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registrodeUsuario_UsuarioInvalidoYaRegistrado()
        {
            dynamic infoUsuario = new
            {
                usuario = "TestUser1",
                email = "testuser3@gmail.com",
                password = "PassTestUser3",
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro = 2000,
                mesRegistro = 1,
                diaRegistro = 1,
                nroIdentificacion = 3,
                telefono = "",
                direccion = "",
                estatus = 1,
                comercio = false,
                nombre = "",
                apellido = "",
                anoNacimiento = 2000,
                mesNacimiento = 1,
                diaNacimiento = 1,
                razonSocial = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.register(infoUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registrodeUsuario_CorreoInvalidoYaRegistrado()
        {
            dynamic infoUsuario = new
            {
                usuario = "TestUser3",
                email = "testuser1@gmail.com",
                password = "PassTestUser3",
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro = 2000,
                mesRegistro = 1,
                diaRegistro = 1,
                nroIdentificacion = 3,
                telefono = "",
                direccion = "",
                estatus = 1,
                comercio = false,
                nombre = "",
                apellido = "",
                anoNacimiento = 2000,
                mesNacimiento = 1,
                diaNacimiento = 1,
                razonSocial = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.register(infoUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
