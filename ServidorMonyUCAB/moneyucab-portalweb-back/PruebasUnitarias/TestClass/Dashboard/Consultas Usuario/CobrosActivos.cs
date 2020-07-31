using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias
{
    [TestClass]
    public class CobrosActivos
    {
        /*Persona registroAdmin1;
        Login loginAdmin1;*/

        TestUser testUser1;

        [TestInitialize]
        public void TestInitialize()
        {
            /*registroAdmin1 = new Persona
            {
                Usuario = "admin1",
                Email = "admin1@gmail.com",
                Password = "admin1",
                IdTipoUsuario = 3,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 1,
                Telefono = "admin1",
                Direccion = "admin1",
                Estatus = 1,
                Comercio = false,
                Nombre = "admin1",
                Apellido = "admin1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "admin1",
            };

            loginAdmin1 = new Login()
            {
                UserName = registroAdmin1.Usuario,
                Email = registroAdmin1.Email,
                Password = registroAdmin1.Password,
                Comercio = registroAdmin1.Comercio
            };*/

            /*testUser1 = new TestUser(1,1);
            testUser1.registrar();*/
            //testUser1.login();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //testUser1.eliminar();
        }

        [TestMethod]
        public void cobros_activos()
        {
            testUser1 = new TestUser(123, 1);
            Task<HttpResponseMessage> res = testUser1.registrar();

            //System.Threading.Thread.Sleep(10000);
            /*Task<HttpResponseMessage> res = APITest.cobros_activos(10, testUser1.getInfoLogin());*/
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
    }
}
