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
            int CuentaId = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.HistorialOperacionesCuenta(CuentaId);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
