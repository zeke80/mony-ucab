using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;


namespace PruebasUnitarias.TestClass.Monedero
{
    [TestClass]
    public class Saldo
    {

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void saldo()
        {
            Task<HttpResponseMessage> res = APITest.Consultar(new 
            {
                idUsuario = 2
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void saldo_idUsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.Consultar(new
            {
                idUsuario = "egreg"
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

    }
}
