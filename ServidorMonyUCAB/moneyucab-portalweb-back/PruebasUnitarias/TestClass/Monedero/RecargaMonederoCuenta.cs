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
    public class RecargaSaldoCuenta
    {
        [TestMethod]
        public void recarga_saldo_cuenta()
        {
            dynamic infoLogin = new
            {
                idUsuarioReceptor = 1,
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoCuenta(infoLogin);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void recarga_saldo_cuenta_UsuarioReceptorInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoCuenta(new
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
        public void recarga_saldo_cuenta_MedioPagaInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoCuenta(new
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
