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
    public class RegistrodeUsuario
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
        public void registrodeUsuario()
        {
            Task<HttpResponseMessage> res = APITest.register(new Persona
            {
                Usuario = "TestUserR",
                Email = "testuserr@gmail.com",
                Password = "testuserr",
                IdTipoUsuario = 1,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = 2020,
                MesRegistro = 1,
                DiaRegistro = 1,
                NroIdentificacion = 1,
                Telefono = "TelfTestUserR",
                Direccion = "DirTestUserR",
                Estatus = 1,
                Comercio = false,
                Nombre = "NomTestUserR",
                Apellido = "ApeTestUserR",
                AnoNacimiento = 1998,
                MesNacimiento = 5,
                DiaNacimiento = 30,
                RazonSocial = "RazTestUserR"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
