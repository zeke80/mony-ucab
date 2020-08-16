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
            int idReintegro = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.CancelarReintegro(idReintegro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        public void cancelarReintegro_idCobroInvalidp()
        {
            int idReintegro = -1;
            Task<HttpResponseMessage> res = null;
            res = APITest.CancelarReintegro(idReintegro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
