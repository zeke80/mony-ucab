using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;
namespace PruebasUnitarias.TestClass.Transfer
{
    [TestClass]
    public class CancelarReintegro
    {
        [TestMethod]
        public void cancelarReintegro()
        {
            Task<HttpResponseMessage> res = APITest.CancelarCobro(1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        public void cancelarReintegro_idCobroInvalidp()
        {
            Task<HttpResponseMessage> res = APITest.CancelarCobro(404);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
    }
}
