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
    public class ReintegrosActivos
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
        public void reintergros_activos()
        {
            int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.ReintegrosActivos(idUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
