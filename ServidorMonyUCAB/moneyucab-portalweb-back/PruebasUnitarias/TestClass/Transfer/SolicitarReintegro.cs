using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias.TestClass.Transfer
{
    [TestClass]
    public class SolicitarReintegro
    {
        [TestMethod]
        public void solicitarReintegro()
        {
            Random ran = new Random();
            int ranNum = ran.Next(100,100000);
            dynamic infoReintegro = new
            {
                idUsuarioSolicitante = 1,
                emailPagador = "TestUser13@gmail.com",
                referencia = ranNum.ToString(),
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.SolicitarReintegro(infoReintegro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void solicitarReintegro_userInvalido()
        {
            Random ran = new Random();
            int ranNum = ran.Next(100, 100000);
            dynamic infoReintegro = new
            {
                idUsuarioSolicitante = -1,
                emailPagador = "TestUser13@gmail.com",
                referencia = ranNum.ToString(),
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.SolicitarReintegro(infoReintegro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void solicitarReintegro_emailInvalido()
        {
            Random ran = new Random();
            int ranNum = ran.Next(100, 100000);
            dynamic infoReintegro = new
            {
                idUsuarioSolicitante = 1,
                emailPagador = "",
                referencia = ranNum.ToString(),
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.SolicitarReintegro(infoReintegro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
