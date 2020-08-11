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
    public class Cuentas
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
        public void cuentas()
        {
            int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.Cuentas(idUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
