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
    public class InformacionPersona
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
        public void informacion_persona()
        {
            string infoPersona = "TestUser1";
            Task<HttpResponseMessage> res = null;
            res = APITest.InformacionPersona(infoPersona);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void informacion_persona_usuarioInvalido()
        {
            string infoPersona = "";
            Task<HttpResponseMessage> res = null;
            res = APITest.InformacionPersona(infoPersona);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
