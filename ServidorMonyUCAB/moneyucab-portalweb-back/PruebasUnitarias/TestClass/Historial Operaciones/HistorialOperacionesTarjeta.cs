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
            Task<HttpResponseMessage> res = APITest.HistorialOperacionesTarjeta(1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

    }
}
