using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias.TestClass.Historial_Operaciones
{
    [TestClass]
    public class HistorialOperacionesTarjeta
    {
        [TestMethod]
        public void historialOperacionTarjeta()
        {
            int TarjetaId = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.HistorialOperacionesTarjeta(TarjetaId);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

    }
}
