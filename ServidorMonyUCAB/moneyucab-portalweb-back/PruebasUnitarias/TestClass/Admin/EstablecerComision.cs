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
    public class EstablecerComision
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
        public void establecerComision()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerComision(new {idComercio =  1,comision = 1});
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void establecerComision_invalidoComercioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerComision(new { idComercio = 404, comision = 1 });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void establecerComision_UsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerComision(new { idComercio = -1, comision = 1 });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
