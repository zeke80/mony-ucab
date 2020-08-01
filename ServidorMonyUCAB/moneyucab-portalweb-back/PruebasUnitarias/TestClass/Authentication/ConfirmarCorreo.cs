using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Authentication
{
    [TestClass]
    public class ConfirmarCorreo
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
        public void confirmarCorreo()
        {
            Task<HttpResponseMessage> res = APITest.ConfirmedEmail(new
            {
                idUsuario = 1,
                confirmationToken = ""
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void confirmarCorreo_invalidoUsuarioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.ConfirmedEmail(new
            {
                idUsuario = 404,
                confirmationToken = ""
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void confirmarCorreo_UsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.ConfirmedEmail(new
            {
                idUsuario = -1,
                confirmationToken = ""
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void confirmarCorreo_TokenInvalido()
        {
            Task<HttpResponseMessage> res = APITest.ConfirmedEmail(new
            {
                idUsuario = 1,
                confirmationToken = ""
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
