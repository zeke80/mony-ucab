﻿using System;
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
    public class RecargaSaldoTarjeta
    {

        Persona registroAdmin1;
        InfoLogin loginAdmin1;
        RecargaSaldoUsuario recargaExito;
        RecargaSaldoUsuario recargaFalloUsuario;
        RecargaSaldoUsuario recargaFalloMedioPaga;

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

            loginAdmin1 = new InfoLogin()
            {
                UserName = registroAdmin1.Usuario,
                Email = registroAdmin1.Email,
                Password = registroAdmin1.Password,
                Comercio = registroAdmin1.Comercio
            };

            recargaExito = new RecargaSaldoUsuario
            {
                IdUsuarioReceptor = 10,
                IdMedioPaga = 3,
                Monto = 100,
                IdOperacion = 1
            };

            recargaFalloUsuario = new RecargaSaldoUsuario
            {
                IdUsuarioReceptor = 100,
                IdMedioPaga = 3,
                Monto = 100,
                IdOperacion = 1
            };

            recargaFalloMedioPaga = new RecargaSaldoUsuario
            {
                IdUsuarioReceptor = 10,
                IdMedioPaga = 100,
                Monto = 100,
                IdOperacion = 1
            };

        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void recarga_saldo_tarjeta()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoTarjeta(recargaExito, loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void recarga_saldo_tarjeta_UsuarioReceptorInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoTarjeta(recargaFalloUsuario, loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void recarga_saldo_tarjeta_MedioPagaInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoTarjeta(recargaFalloMedioPaga, loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

    }
}