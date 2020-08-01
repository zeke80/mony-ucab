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
    public class EjecutarCierre
    {
        [TestMethod]
        public void ejecutarCierre()
        {
            Task<HttpResponseMessage> res = APITest.EjecutarCierre(new
            {
                TarjetaID = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void ejecutarCierre_idInvalido()
        {
            Task<HttpResponseMessage> res = APITest.EjecutarCierre(new
            {
                TarjetaID = "efsrdt"
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
