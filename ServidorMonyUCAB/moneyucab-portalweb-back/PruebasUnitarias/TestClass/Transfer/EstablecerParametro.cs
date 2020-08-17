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
    //[TestClass]
    public class EstablecerParametro
    {
        [TestMethod]
        public void establecerParametro()
        {
            dynamic infoParametro = new
            {
                idUsuario = 1,
                idParametro = 1,
                validacion = "1000",
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.EstablecerParametro(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void establecerParametro_idUsuarioInvalido()
        {
            dynamic infoParametro = new
            {
                idUsuario = -1,
                idParametro = 1,
                validacion = "1000",
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.EstablecerParametro(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void establecerParametro_idParametroInvalido()
        {
            dynamic infoParametro = new
            {
                idUsuario = 1,
                idParametro = -1,
                validacion = "1000",
                estatus = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.EstablecerParametro(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
