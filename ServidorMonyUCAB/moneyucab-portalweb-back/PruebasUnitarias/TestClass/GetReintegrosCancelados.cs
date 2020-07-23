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
    public class GetReintegrosCancelados
    {
        [TestMethod]
        public void consultaReintegrosCancelados()
        {
            Task.Run(async () =>
            {
                HttpResponseMessage res = await APITest.getReintegrosActivos(1, 2);
                Assert.IsTrue(res.StatusCode == HttpStatusCode.Unauthorized);
            }).GetAwaiter().GetResult();
        }
    }
}
