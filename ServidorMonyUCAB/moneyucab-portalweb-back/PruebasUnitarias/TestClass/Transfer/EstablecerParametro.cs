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
    public class EstablecerParametro
    {
        [TestMethod]
        public void establecerParametro()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerParametro(new
            {
                idUsuario = 2,
                idParametro = 1,
                validacion = "",
                estatus = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void establecerParametro_idUsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerParametro(new
            {
                idUsuario = 404,
                idParametro = 1,
                validacion = "",
                estatus = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void establecerParametro_idParametroInvalido()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerParametro(new
            {
                idUsuario = 2,
                idParametro = 400,
                validacion = "",
                estatus = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void establecerParametro_estatusInvalido()
        {
            Task<HttpResponseMessage> res = APITest.EstablecerParametro(new
            {
                idUsuario = 2,
                idParametro = 1,
                validacion = 100,
                estatus = ""
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
