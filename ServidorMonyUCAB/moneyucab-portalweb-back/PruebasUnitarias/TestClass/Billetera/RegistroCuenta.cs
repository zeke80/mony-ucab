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
    public class RegistroCuenta
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
            Random ran = new Random();
            int ranNum = ran.Next(200, 100000);
            dynamic cuenta = new
            {
                idUsuario = 1,
                idTipoCuenta = 1,
                idBanco = 1,
                numero = ranNum.ToString()
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Cuenta(cuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registroCuenta_invalidoUsuarioNoRegistrado()
        {
            Random ran = new Random();
            int ranNum = ran.Next(200, 100000);
            dynamic cuenta = new
            {
                idUsuario = -1,
                idTipoCuenta = 1,
                idBanco = 1,
                numero = ranNum.ToString()
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Cuenta(cuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroCuenta_invalidoTipoCuentaNoRegistrada()
        {
            Random ran = new Random();
            int ranNum = ran.Next(200, 100000);
            dynamic cuenta = new
            {
                idUsuario = 1,
                idTipoCuenta = -1,
                idBanco = 1,
                numero = ranNum.ToString()
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Cuenta(cuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroCuenta_invalidoBancoNoRegistrado()
        {
            Random ran = new Random();
            int ranNum = ran.Next(200, 100000);
            dynamic cuenta = new
            {
                idUsuario = 1,
                idTipoCuenta = 1,
                idBanco = -1,
                numero = ranNum.ToString()
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Cuenta(cuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
