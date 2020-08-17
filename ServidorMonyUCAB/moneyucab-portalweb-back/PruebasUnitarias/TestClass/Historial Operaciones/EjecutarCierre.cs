using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias.TestClass.Historial_Operaciones
{
    [TestClass]
    public class EjecutarCierre
    {
        [TestMethod]
        public void ejecutarCierre()
        {
            int IdUsuario = 13;
            Task<HttpResponseMessage> res = null;
            res = APITest.EjecutarCierre(IdUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void ejecutarCierre_idUsuarioInvalido()
        {
            int IdUsuario = -1;
            Task<HttpResponseMessage> res = null;
            res = APITest.EjecutarCierre(IdUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
