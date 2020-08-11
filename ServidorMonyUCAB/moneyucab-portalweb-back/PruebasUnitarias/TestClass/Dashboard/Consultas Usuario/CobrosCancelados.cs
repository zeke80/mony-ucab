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
    public class CobrosCancelados
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
        public void cobros_cancelados()
        {
            int idUsuario = 1;
            int solicitante = 2;
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.CobrosCancelados(idUsuario, solicitante);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
