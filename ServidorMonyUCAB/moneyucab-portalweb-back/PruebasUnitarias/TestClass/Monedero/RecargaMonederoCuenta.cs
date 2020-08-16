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
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 47,
                monto = 100,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void recarga_saldo_cuenta_UsuarioReceptorInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 47,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void recarga_saldo_cuenta_MedioPagaInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RecargaMonederoCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
