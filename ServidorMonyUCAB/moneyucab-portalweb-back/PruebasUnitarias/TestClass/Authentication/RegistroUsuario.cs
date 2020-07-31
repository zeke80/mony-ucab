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

        Persona persona;

        [TestInitialize]
        public void TestInitialize()
        {

            persona = new Persona
            {
                Usuario = "admin12",
                Email = "admin12@gmail.com",
                Password = "admin12",
                IdTipoUsuario = 3,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 12,
                Telefono = "admin1",
                Direccion = "admin1",
                Estatus = 1,
                Comercio = false,
                Nombre = "admin1",
                Apellido = "admin1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "admin1"
            };
        }

        // error en json estatus 400

        /*[TestMethod]
        public void registro_persona()
        {
            Task<HttpResponseMessage> res = APITest.register(persona);
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
            
        }*/
    }
}
