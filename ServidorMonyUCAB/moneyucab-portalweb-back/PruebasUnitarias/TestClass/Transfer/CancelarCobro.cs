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
            /*int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.CancelarCobro(idUsuario, solicitante);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);*/
        }

        public void cancelarCobro_idCobroInvalidp()
        {
            Task<HttpResponseMessage> res = APITest.CancelarCobro(404);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
    }
}
