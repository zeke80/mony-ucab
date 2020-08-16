using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias.TestClass.Monedero
{
    [TestClass]
    public class RecargaSaldoTarjeta
    {

        [TestMethod]
        public void recarga_saldo_tarjeta()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 13,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoTarjeta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void recarga_saldo_tarjeta_UsuarioReceptorInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 13,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoTarjeta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void recarga_saldo_tarjeta_MedioPagaInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoTarjeta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

    }
}
