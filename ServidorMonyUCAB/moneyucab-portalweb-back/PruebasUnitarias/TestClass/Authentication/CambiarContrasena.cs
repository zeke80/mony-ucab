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
    //[TestClass]
    public class CambiarContrasena
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
        public void cambiarContrasena()
        {
            dynamic infoCambiarContrasena = new
            {
                idComercio = 1,
                comision = 1,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ChangePassword(infoCambiarContrasena);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void cambiarContrasena_invalidoUsuarioNoRegistrado()
        {
            dynamic infoCambiarContrasena = new
            {
                idComercio = 1,
                comision = 1,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ChangePassword(infoCambiarContrasena);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void cambiarContrasena_UsuarioInvalido()
        {
            dynamic infoCambiarContrasena = new
            {
                idComercio = 1,
                comision = 1,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ChangePassword(infoCambiarContrasena);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
