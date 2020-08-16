using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Admin
{
    [TestClass]
    public class EstablecerLimiteParametro
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
        public void establecerLimiteParametro()
        {
            dynamic infoParametro = new
            {
                idParametro = 1,
                limite = "100",
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.EstablecerLimiteParametro(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void establecerLimiteParametro_invalidoParametroNoRegistrado()
        {
            dynamic infoParametro = new
            {
                idParametro = -1,
                limite = "100",
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.EstablecerLimiteParametro(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
