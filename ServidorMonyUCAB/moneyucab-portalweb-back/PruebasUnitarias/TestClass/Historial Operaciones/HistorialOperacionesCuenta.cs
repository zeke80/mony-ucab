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
    public class HistorialOperacionesCuenta
    {
        [TestMethod]
        public void historialOperacionesCuenta()
        {
            Task<HttpResponseMessage> res = APITest.HistorialOperacionesCuenta(1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
    }
}
