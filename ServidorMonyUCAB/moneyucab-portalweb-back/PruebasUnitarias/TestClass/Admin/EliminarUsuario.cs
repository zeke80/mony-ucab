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
    class EliminarUsuario
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        public void eliminarUsuario()
        {
            Task<HttpResponseMessage> res = APITest.EliminarUsuario(1);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        public void eliminarUsuario_invalidoNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.EliminarUsuario(404);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        public void eliminarUsuario_ParametroInvalido()
        {
            Task<HttpResponseMessage> res = APITest.EliminarUsuario(-1);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
