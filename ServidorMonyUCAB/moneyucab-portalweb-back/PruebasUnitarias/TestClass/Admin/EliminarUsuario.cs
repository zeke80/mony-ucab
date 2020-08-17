using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Admin
{
    //[TestClass]
    public class EliminarUsuario
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Random ran = new Random();
            int ranNum = ran.Next(200, 1000);
            dynamic infoUsuario = new
            {
                usuario = "TestUser5000",
                email = "TestUser5000@gmail.com",
                password = "TestUser5000",
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro = 2000,
                mesRegistro = 1,
                diaRegistro = 1,
                nroIdentificacion = 5000,
                telefono = "",
                direccion = "",
                estatus = 1,
                comercio = false,
                nombre = "",
                apellido = "",
                anoNacimiento = 2000,
                mesNacimiento = 1,
                diaNacimiento = 1,
                razonSocial = ""
            };
            APITest.register(infoUsuario);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void eliminarUsuario()
        {
            string infoPersona = "TestUser5000";
            dynamic resp = APITest.InformacionPersona(infoPersona);

            int idUsuario = resp.Result.Content.result.idEntity;
            Task<HttpResponseMessage> res = null;
            res = APITest.EliminarUsuario(idUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void eliminarUsuario_invalidoNoRegistrado()
        {
            int idUsuario = -1;
            Task<HttpResponseMessage> res = null;
            res = APITest.EliminarUsuario(idUsuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
