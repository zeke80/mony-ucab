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
    public class CambiarContrasena
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
        public void cambiarContrasena()
        {
            dynamic infoParametro = new
            {
                idUsuario = 1,
                resetPasswordToken = "",
                newPassword = "PassTestUser1"
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.ChangePassword(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void cambiarContrasena_invalidoUsuarioNoRegistrado()
        {
            dynamic infoParametro = new
            {
                idUsuario = -1,
                resetPasswordToken = "",
                newPassword = "PassTestUser1"
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.ChangePassword(infoParametro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
