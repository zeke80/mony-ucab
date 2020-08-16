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
    public class RegistroComercio
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
            dynamic correo = new
            {
                usuario = "TestUser1",
                idUsuario = 1,
                razonSocial = "RazTestUser1",
                nombre = "NomTestUser1",
                apellido = "ApeTestUser1",
                comision = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RegisterComercio(correo);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registroComercio_InvalidoUsuarioNoRegistrado()
        {
            dynamic correo = new
            {
                usuario = "TestUser1",
                idUsuario = -1,
                razonSocial = "RazTestUser1",
                nombre = "NomTestUser1",
                apellido = "ApeTestUser1",
                comision = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RegisterComercio(correo);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroComercio_InvalidoUsuarioNoRegistradoXUserName()
        {
            dynamic correo = new
            {
                usuario = "",
                idUsuario = 1,
                razonSocial = "RazTestUser1",
                nombre = "NomTestUser1",
                apellido = "ApeTestUser1",
                comision = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RegisterComercio(correo);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
