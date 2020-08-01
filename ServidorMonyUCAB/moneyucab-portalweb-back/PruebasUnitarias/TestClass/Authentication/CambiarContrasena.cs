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
            Task<HttpResponseMessage> res = APITest.ChangePassword(new {
                idUsuario = 1,
                resetPasswordToken = "pas12", 
                newPassword = "pass123"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void cambiarContrasena_invalidoUsuarioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.ChangePassword(new
            {
                idUsuario = 404,
                resetPasswordToken = "pas12",
                newPassword = "pass123"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void cambiarContrasena_UsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.ChangePassword(new
            {
                idUsuario = -1,
                resetPasswordToken = "pas12",
                newPassword = "pass123"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
