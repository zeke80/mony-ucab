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
            Task<HttpResponseMessage> res = APITest.RecargaMonederoTarjeta(new
            {
                idUsuarioReceptor = 2,
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void recarga_saldo_tarjeta_UsuarioReceptorInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoTarjeta(new
            {
                idUsuarioReceptor = "qere",
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void recarga_saldo_tarjeta_MedioPagaInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoTarjeta(new
            {
                idUsuarioReceptor = 2,
                idMedioPaga = "qwewrf",
                monto = 100,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

    }
}
