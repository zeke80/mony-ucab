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
    public class CancelarCobro
    {
        [TestMethod]
        public void cancelarCobro()
        {
            int idCobro = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.CancelarCobro(idCobro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void cancelarCobro_idCobroInvalidp()
        {
            int idCobro = -1;
            Task<HttpResponseMessage> res = null;
            res = APITest.CancelarCobro(idCobro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
