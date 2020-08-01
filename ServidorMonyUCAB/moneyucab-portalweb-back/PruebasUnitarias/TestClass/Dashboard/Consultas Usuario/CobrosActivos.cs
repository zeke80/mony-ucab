using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias
{
    [TestClass]
    public class CobrosActivos
    {

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void cobros_activos()
        {
            /*Task<HttpResponseMessage> res = APITest.CobrosActivos(10, testUser1.getInfoLogin());
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);*/
        }
    }
}
