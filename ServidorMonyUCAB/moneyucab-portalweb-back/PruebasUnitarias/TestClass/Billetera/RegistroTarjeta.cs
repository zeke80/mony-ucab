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
    public class RegistroTarjeta
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
        public void registroTarjeta()
        {
            dynamic tarjeta = new
            {
                idUsuario = 1,
                idTipoTarjeta = 1,
                idBanco = 1,
                numero = 1,
                ano = 2021,
                mes = 5,
                dia = 30,
                cvc = 1550,
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.tarjeta(tarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void registroTarjeta_invalidoUsuarioNoRegistrado()
        {
            dynamic tarjeta = new
            {
                idUsuario = -1,
                idTipoTarjeta = 1,
                idBanco = 1,
                numero = 1,
                ano = 2021,
                mes = 5,
                dia = 30,
                cvc = 1550,
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.tarjeta(tarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroTarjeta_invalidoTipoTarjetaNoRegistrada()
        {
            dynamic tarjeta = new
            {
                idUsuario = 1,
                idTipoTarjeta = -1,
                idBanco = 1,
                numero = 1,
                ano = 2021,
                mes = 5,
                dia = 30,
                cvc = 1550,
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.tarjeta(tarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void registroTarjeta_invalidoBancoNoRegistrado()
        {
            dynamic tarjeta = new
            {
                idUsuario = 1,
                idTipoTarjeta = 1,
                idBanco = -1,
                numero = 1,
                ano = 2021,
                mes = 5,
                dia = 30,
                cvc = 1550,
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.tarjeta(tarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
