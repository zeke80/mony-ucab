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
    public class RestablecerContrasena
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
        public void restablecerContrasena()
        {
            Task<HttpResponseMessage> res = APITest.ResetPassword(new
            {
                idUsuario = 1,
                resetPasswordToken = "testuser",
                newPassword = "testuser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void restablecerContrasena_invalidoUsuarioNoRegistrado()
        {
            Task<HttpResponseMessage> res = APITest.ResetPassword(new
            {
                idUsuario = 404,
                resetPasswordToken = "testuser",
                newPassword = "testuser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void restablecerContrasena_UsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.ResetPassword(new
            {
                idUsuario = -1,
                resetPasswordToken = "testuser",
                newPassword = "testuser"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
