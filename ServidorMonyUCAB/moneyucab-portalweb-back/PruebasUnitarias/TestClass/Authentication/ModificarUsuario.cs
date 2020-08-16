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
    public class ModificarUsuario
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
            dynamic infoModificacionUsuario = new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = 1,
                idUsuario = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.modification(infoModificacionUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void modificarUsuario_invalidoUsuarioNoRegistrado()
        {
            dynamic infoModificacionUsuario = new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = 1,
                idUsuario = -1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.modification(infoModificacionUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void modificarUsuario_InvalidoEstadoCivilNoRegistrado()
        {
            dynamic infoModificacionUsuario = new
            {
                nombre = "NomTestUser",
                apellido = "ApeTestUser",
                telefono = "TelfTestUser",
                direccion = "DirTestUser",
                razonSocial = "RazTestUser",
                idEstadoCivil = -1,
                idUsuario = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.modification(infoModificacionUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
