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
    //[TestClass]
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
            dynamic infoConfirmacionCorreo = new
            {
                idUsuario = 1,
                confirmationToken = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ConfirmedEmail(infoConfirmacionCorreo);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void confirmarCorreo_invalidoUsuarioNoRegistrado()
        {
            dynamic infoConfirmacionCorreo = new
            {
                idUsuario = 1,
                confirmationToken = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ConfirmedEmail(infoConfirmacionCorreo);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void confirmarCorreo_UsuarioInvalido()
        {
            dynamic infoConfirmacionCorreo = new
            {
                idUsuario = 1,
                confirmationToken = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ConfirmedEmail(infoConfirmacionCorreo);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void confirmarCorreo_TokenInvalido()
        {
            dynamic infoConfirmacionCorreo = new
            {
                idUsuario = 1,
                confirmationToken = ""
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.ConfirmedEmail(infoConfirmacionCorreo);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
