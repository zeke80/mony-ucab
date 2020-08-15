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
            dynamic infoComision = new {
                idComercio =  1,
                comision = 1,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.EstablecerComision(infoComision);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void establecerComision_invalidoComercioNoRegistrado()
        {
            dynamic infoComision = new
            {
                idComercio = 1,
                comision = 1,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.EstablecerComision(infoComision);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void establecerComision_UsuarioInvalido()
        {
            dynamic infoComision = new
            {
                idComercio = 1,
                comision = 1,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.EstablecerComision(infoComision);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
