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
    public class ConsultaFamiliares
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
        public void consulta_familiares()
        {
            int idUsuario = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.ConsultaUsuariosF(idUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
