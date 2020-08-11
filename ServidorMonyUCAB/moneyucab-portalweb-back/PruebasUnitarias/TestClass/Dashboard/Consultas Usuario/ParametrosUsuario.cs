using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Dashboard.Consultas_Usuario
{
    [TestClass]
    public class ParametrosUsuario
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
        public void parametros_usuario()
        {
            int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ParametrosUsuario(idUsuario);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
