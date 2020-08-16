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
    public class RegistroFamiliar
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
        public void registroFamiliar()
        {
            Task<HttpResponseMessage> res = APITest.RegisterFamiliar(new 
            {
               Usuario = "TestUserF",
               Email = "testuserf@gmail.com",
               Password = "testuserf",
               IdTipoUsuario =  1,
               IdTipoIdentificacion = 1,
               IdEstadoCivil = 1,
               AnoRegistro = 2020,
               MesRegistro = 1,
               DiaRegistro = 1,
               NroIdentificacion =  1,
               Telefono = "TelfTestUserF",
               Direccion = "DirTestUserF",
               Estatus =  1,
               Comercio =  false,
               Nombre = "NomTestUserF",
               Apellido = "ApeTestUserF",
               AnoNacimiento =  1998,
               MesNacimiento =  5,
               DiaNacimiento = 30,
               RazonSocial = "RazTestUserF"
            });
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
