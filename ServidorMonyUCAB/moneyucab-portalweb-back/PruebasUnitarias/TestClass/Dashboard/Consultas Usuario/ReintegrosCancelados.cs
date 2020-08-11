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
    public class ReintegrosCancelados
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
        public void reintergros_cancelados()
        {
            int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ReintegrosCancelados(idUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
