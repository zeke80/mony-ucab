using Comunes.Comun;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Sdk;

namespace Pruebas_Unitarias.PruebasUnitarias
{
    [TestClass]
    public class ConexiónLógicaDAO
    {
        private ComUsuario usuario;
        private ComCuenta cuenta;
        private ComTarjeta tarjeta;
        private ComUsuarioParametro parametro;

        [TestInitialize]
        public void InicializacionValores()
        {
            throw new NotImplementedException();
        }
    }
}
