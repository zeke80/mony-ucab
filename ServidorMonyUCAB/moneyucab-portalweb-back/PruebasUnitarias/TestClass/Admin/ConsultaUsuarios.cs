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
    public class ConsultaUsuarios
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
        public void consultaUsuarios()
        {
            string query = "WHERE Usuario.idUsuario = 1";
            Task<HttpResponseMessage> res = null;
            res = APITest.ConsultaUsuarios(query);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void consultaUsuarios_invalido()
        {
            string query = "";
            Task<HttpResponseMessage> res = null;
            res = APITest.ConsultaUsuarios(query);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
