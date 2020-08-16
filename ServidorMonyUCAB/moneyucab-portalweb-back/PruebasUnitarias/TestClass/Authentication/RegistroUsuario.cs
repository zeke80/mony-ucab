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
                usuario = "TestUser4",
                email = "testuser4@gmail.com",
                password = "PassTestUser4",
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
            res = APITest.register(infoUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registrodeUsuario_UsuarioInvalidoYaRegistrado()
        {
            dynamic infoUsuario = new
            {
                usuario = "TestUser4",
                email = "testuser5@gmail.com",
                password = "PassTestUser5",
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
            res = APITest.register(infoUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registrodeUsuario_CorreoInvalidoYaRegistrado()
        {
            dynamic infoUsuario = new
            {
                usuario = "TestUser5",
                email = "testuser4@gmail.com",
                password = "PassTestUser5",
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
            res = APITest.register(infoUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
