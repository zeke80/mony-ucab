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
    class ModificarUsuario
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
        public void modificarUsuario()
        {
            Task<HttpResponseMessage> res = APITest.modification(new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = 1,
                idUsuario = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void modificarUsuario_invalidoUsuarioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.modification(new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = 1,
                idUsuario = 404
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void modificarUsuario_UsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.modification(new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = 1,
                idUsuario = -1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void modificarUsuario_InvalidoEstadoCivilNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.modification(new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = 404,
                idUsuario = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void modificarUsuario_EstadoCivilInvalido()
        {
            Task<HttpResponseMessage> res = APITest.modification(new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = -1,
                idUsuario = 1
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
