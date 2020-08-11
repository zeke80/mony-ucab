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
    public class EliminarUsuario
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
        public void eliminarUsuario()
        {
            int idUsuario = 3;
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.EliminarUsuario(idUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void eliminarUsuario_invalidoNoRegistrado()
        {
            int idUsuario = 0;
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.EliminarUsuario(idUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
