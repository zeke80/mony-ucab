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
            Random ran = new Random();
            int ranNum = ran.Next(200, 1000);
            dynamic infoUsuario = new
            {
                usuario = "TestUser" + ranNum,
                email = "TestUser" + ranNum + "@gmail.com",
                password = "TestUser" + ranNum,
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro =2000,
                mesRegistro =1,
                diaRegistro =1,
                nroIdentificacion = ranNum,
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
            Random ran = new Random();
            int ranNum = ran.Next(200, 1000);
            dynamic infoUsuario = new
            {
                usuario = "TestUser1",
                email = "TestUser" + ranNum + "@gmail.com",
                password = "TestUser" + ranNum,
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro = 2000,
                mesRegistro = 1,
                diaRegistro = 1,
                nroIdentificacion = ranNum,
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
            Random ran = new Random();
            int ranNum = ran.Next(200, 1000);
            dynamic infoUsuario = new
            {
                usuario = "TestUser" + ranNum,
                email = "TestUser1@gmail.com",
                password = "TestUser" + ranNum,
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro = 2000,
                mesRegistro = 1,
                diaRegistro = 1,
                nroIdentificacion = ranNum,
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
