using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Billetera
{
    [TestClass]
    class RegistroCuenta
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
        public void registroCuenta()
        {
            Task<HttpResponseMessage> res = APITest.Cuenta(new
            {
                idUsuario = 1,
                idTipoCuenta = 1,
                idBanco = 1,
                numero = "NumCuentaTestUser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registroCuenta_invalidoUsuarioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.Cuenta(new
            {
                idUsuario = 404,
                idTipoCuenta = 1,
                idBanco = 1,
                numero = "NumCuentaTestUser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroCuenta_invalidoTipoCuentaNoRegistrada()
        {
            Task<HttpResponseMessage> res = APITest.Cuenta(new
            {
                idUsuario = 1,
                idTipoCuenta = 404,
                idBanco = 1,
                numero = "NumCuentaTestUser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroCuenta_invalidoBancoNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.Cuenta(new
            {
                idUsuario = 1,
                idTipoCuenta = 1,
                idBanco = 404,
                numero = "NumCuentaTestUser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
