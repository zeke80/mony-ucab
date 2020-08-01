using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Authentication
{
    [TestClass]
    class RegistroComercio
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
        public void registroComercio()
        {
            Task<HttpResponseMessage> res = APITest.RegisterComercio(new
            {
                usuario = "TestUser",
                idUsuario = 1,
                razonSocial = "RazTestUser",
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                comision = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registroComercio_InvalidoUsuarioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.RegisterComercio(new
            {
                usuario = "TestUser",
                idUsuario = 404,
                razonSocial = "RazTestUser",
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                comision = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroComercio_InvalidoUsuarioNoRegistradoXUserName()
        {
            Task<HttpResponseMessage> res = APITest.RegisterComercio(new
            {
                usuario = "",
                idUsuario = 1,
                razonSocial = "RazTestUser",
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                comision = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroComercio_UsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RegisterComercio(new
            {
                usuario = "TestUser",
                idUsuario = -1,
                razonSocial = "RazTestUser",
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                comision = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
