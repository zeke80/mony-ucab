using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebasUnitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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
            dynamic infoLogin= new
            {
                username = "TestUser1",
                email = "testuser1@gmail.com",
                password = "PassTestUser1",
                comercio = false,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.login(infoLogin);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);          
        }

        /*[TestMethod]
        public void login_UserNameInvalido()
        {
            dynamic infoLogin = new
            {
                username = "",
                email = "testuser1@gmail.com",
                password = "PassTestUser1",
                comercio = false,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.login(infoLogin);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }*/

        [TestMethod]
        public void login_EmailInvalido()
        {
            dynamic infoLogin = new
            {
                username = "TestUser1",
                email = "",
                password = "PassTestUser1",
                comercio = false,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.login(infoLogin);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void login_PasswordInvalido()
        {
            dynamic infoLogin = new
            {
                username = "TestUser1",
                email = "testuser1@gmail.com",
                password = "",
                comercio = false,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.login(infoLogin);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void login_ComercioInvalido()
        {
            dynamic infoLogin = new
            {
                username = "TestUser1",
                email = "testuser1@gmail.com",
                password = "PassTestUser1",
                comercio = true,
            };
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.login(infoLogin);
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
