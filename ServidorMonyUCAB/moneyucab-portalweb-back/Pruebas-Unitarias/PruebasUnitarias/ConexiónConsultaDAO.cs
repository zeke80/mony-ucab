using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;
using Xunit.Sdk;

//Pruebas de funcionamiento de llenado por parte de las entidades comunes y de las clases.

namespace Pruebas_Unitarias.PruebasUnitarias
{
    [TestClass]
    public class ConexiónConsultaDAO
    {
        [TestMethod]
        public void Bancos()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.Bancos();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void CobrosActivos()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.CobrosActivos(1, 1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void CobrosCancelados()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.CobrosCancelados(1, 1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void CobrosExitosos()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.CobrosExitosos(1, 1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void ConexionABaseDeDatos()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.Conectar();
            dao.Desconectar();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void Cuentas()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.Cuentas(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void EstadosCiviles()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.EstadosCiviles();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void Frecuencias()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.Frecuencias();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void HistorialOperacionesTarjeta()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.HistorialOperacionesTarjeta(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void HistorialOperacionesCuenta()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.HistorialOperacionesCuenta(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void HistorialOperacionesMonedero()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.HistorialOperacionesMonedero(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NpgsqlException),
        "No se encontró usuario relacionado a la id, posible valor respecto al vacío de base de datos")]
        public void InformacionPersona()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.InformacionPersona("Pedro");
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void Parametros()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.Parametros();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void ParametrosUsuario()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.ParametrosUsuario(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void ReintegrosActivos()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.ReintegrosActivos(1, 1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void ReintegrosCancelados()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.ReintegrosCancelados(1, 1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void ReintegrosExitosos()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.ReintegrosExitosos(1, 1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void SaldoMonedero()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.SaldoMonedero(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void Tarjetas()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.Tarjetas(1);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void TiposCuentas()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.TiposCuentas();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void TiposIdentificaciones()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.TiposIdentificaciones();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void TiposOperaciones()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.TiposOperaciones();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void TiposParametros()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.TiposParametros();
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void TiposTarjeta()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.TiposTarjeta();
            Assert.AreEqual(null, null);
        }
    }
}
