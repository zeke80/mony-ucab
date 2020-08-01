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
    public class InformacionPersona
    {
        Persona registroAdmin1;
        Login loginAdmin1;

        [TestInitialize]
        public void TestInitialize()
        {
            registroAdmin1 = new Persona
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
            };

        }
        [TestMethod]
        public void informacion_persona()
        {
            Task<HttpResponseMessage> res = APITest.InformacionPersona(registroAdmin1.Usuario, loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void informacion_persona_usuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.InformacionPersona("wegrr", loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
