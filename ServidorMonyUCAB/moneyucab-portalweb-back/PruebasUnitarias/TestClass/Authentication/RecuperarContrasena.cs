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
    public class RecuperarContrasena
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
        public void recuperarContrasena()
        {
            dynamic correo = new { 
                email = "testuser1@gmail.com", 
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.ForgotPasswordEmail(correo);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void recuperarContrasena_EmailInvalido()
        {
            dynamic correo = new
            {
                email = "",
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.ForgotPasswordEmail(correo);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
