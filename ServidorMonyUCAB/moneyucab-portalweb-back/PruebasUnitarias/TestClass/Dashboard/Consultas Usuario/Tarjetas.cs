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
    public class Tarjetas
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
        public void tarjetas()
        {
            int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.Tarjetas(idUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
