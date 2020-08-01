using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebasUnitarias.Modelos;
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
    public class Login
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
        public void login()
        {
            Task<HttpResponseMessage> res = APITest.login(new InfoLogin
            {
                UserName = "TestUser",
                Email = "testuser@gmail.com",
                Password = "passtestuser",
                Comercio = false,
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void login_UserNameInvalido()
        {
            Task<HttpResponseMessage> res = APITest.login(new InfoLogin
            {
                UserName = "",
                Email = "testuser@gmail.com",
                Password = "passtestuser",
                Comercio = false,
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void login_EmailInvalido()
        {
            Task<HttpResponseMessage> res = APITest.login(new InfoLogin
            {
                UserName = "TestUser",
                Email = "",
                Password = "passtestuser",
                Comercio = false,
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void login_PasswordInvalido()
        {
            Task<HttpResponseMessage> res = APITest.login(new InfoLogin
            {
                UserName = "TestUser",
                Email = "testuser@gmail.com",
                Password = "",
                Comercio = false,
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void login_ComercioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.login(new InfoLogin
            {
                UserName = "TestUser",
                Email = "testuser@gmail.com",
                Password = "passtestuser",
                Comercio = true,
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
