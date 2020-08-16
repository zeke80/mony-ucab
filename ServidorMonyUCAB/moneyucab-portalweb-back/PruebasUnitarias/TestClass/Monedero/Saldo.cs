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
            int idusuario = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.Consultar(idusuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void saldo_idUsuarioInvalido()
        {
            int idusuario = -1;
            Task<HttpResponseMessage> res = null;
            res = APITest.Consultar(idusuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

    }
}
