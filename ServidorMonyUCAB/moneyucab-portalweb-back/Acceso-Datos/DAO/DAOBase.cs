using Comunes.Comun;
using DAO.Interfaces;
using Excepciones;
using Excepciones.Excepciones_Especificas;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DAO
{
    /// <summary>
    /// Class <c>DAOLogin</c>
    /// Establece la clase para el manejo de datos query a través de PostgreSQL.
    /// </summary>
    public class DAOBase : DAOPsql, IDAOLogic
    {

        /// <summary>
        /// Establece la creación del DAO para el manejo del módulo de ingreso a través de la base de datos.
        /// </summary>
        public DAOBase()
        {
            NpgsqlConnectionStringBuilder conn_string = new NpgsqlConnectionStringBuilder();
            //////////          LOCAL             ///////////////
            /*conn_string.Host = "localhost";
            conn_string.Port = 5432;
            conn_string.Username = "postgres";
            conn_string.Password = "lolazo123";              
            conn_string.Database = "postgres";*/

            ///////////REMOTO BASE DE DATOS HEROKU///////////////
            conn_string.Host = "ec2-52-203-160-194.compute-1.amazonaws.com";
            conn_string.Port = 5432;
            conn_string.Username = "ppaslmipvfumce";
            conn_string.Password = "5daf33bd4e95b74bc2dc0ef64d9b21a2d8fe83b0d602e4db97cca72d5f7627c6";
            conn_string.Database = "d1psqo5qceht6j";
            conn_string.SslMode = SslMode.Require;
            conn_string.TrustServerCertificate = true;


            stringConexion = conn_string.ToString();
        }

        //Operaciones de consulta---------------------------------------------------------------
        public List<ComEstadoCivil> EstadosCiviles()
        {

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Estados_Civiles();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComEstadoCivil> estadosCiviles = new List<ComEstadoCivil>();
                ComEstadoCivil row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComEstadoCivil();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    estadosCiviles.Add(row);
                }
                return estadosCiviles;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComTipoTarjeta> TiposTarjeta()
        {


            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM tipos_tarjeta();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoTarjeta> tiposTarjetas = new List<ComTipoTarjeta>();
                ComTipoTarjeta row = new ComTipoTarjeta();
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoTarjeta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposTarjetas.Add(row);
                }
                return tiposTarjetas;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComBanco> Bancos()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Bancos();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComBanco> bancos = new List<ComBanco>();
                ComBanco row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComBanco();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    bancos.Add(row);
                }
                return bancos;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComTipoCuenta> TiposCuentas()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Cuentas();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoCuenta> tiposCuentas = new List<ComTipoCuenta>();
                ComTipoCuenta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoCuenta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposCuentas.Add(row);
                }
                return tiposCuentas;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComTipoParametro> TiposParametros()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Parametros();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoParametro> tiposParametros = new List<ComTipoParametro>();
                ComTipoParametro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoParametro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposParametros.Add(row);
                }
                return tiposParametros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComFrecuencia> Frecuencias()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Frecuencias();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComFrecuencia> frecuencias = new List<ComFrecuencia>();
                ComFrecuencia row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComFrecuencia();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    frecuencias.Add(row);
                }
                return frecuencias;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComParametro> Parametros()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Parametros();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComParametro> parametros = new List<ComParametro>();
                ComParametro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComParametro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    parametros.Add(row);
                }
                return parametros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComTipoOperacion> TiposOperaciones()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Operaciones();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoOperacion> tiposOperaciones = new List<ComTipoOperacion>();
                ComTipoOperacion row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoOperacion();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposOperaciones.Add(row);
                }
                return tiposOperaciones;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComTipoIdentificacion> TiposIdentificaciones()
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Identificaciones();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoIdentificacion> tiposIdentificaciones = new List<ComTipoIdentificacion>();
                ComTipoIdentificacion row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoIdentificacion();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposIdentificaciones.Add(row);
                }
                return tiposIdentificaciones;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComTarjeta> Tarjetas(int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tarjetas(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTarjeta> tarjetas = new List<ComTarjeta>();
                ComTarjeta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTarjeta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tarjetas.Add(row);
                }
                return tarjetas;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null; 
        }

        public List<ComCuenta> Cuentas(int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cuentas(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                List<ComCuenta> cuentas = new List<ComCuenta>();
                ComCuenta row;
                lectorTablaSQL = comandoSQL.ExecuteReader();
                while (lectorTablaSQL.Read())
                {
                    row = new ComCuenta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cuentas.Add(row);
                }
                return cuentas;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComReintegro> ReintegrosActivos(int IdUsuario, int Solicitante)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Activos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    reintegros.Add(row);
                }
                return reintegros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComReintegro> ReintegrosCancelados(int IdUsuario, int Solicitante)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Cancelados(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    reintegros.Add(row);
                }
                return reintegros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComReintegro> ReintegrosExitosos(int IdUsuario, int Solicitante)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Exitosos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    reintegros.Add(row);
                }
                return reintegros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComPago> CobrosActivos(int IdUsuario, int Solicitante)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Activos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cobros.Add(row);
                }
                return cobros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComPago> CobrosCancelados(int IdUsuario, int Solicitante)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Cancelados(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cobros.Add(row);
                }
                return cobros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComPago> CobrosExitosos(int IdUsuario, int Solicitante)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Exitosos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cobros.Add(row);
                }
                return cobros;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComUsuarioParametro> ParametrosUsuario(int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Parametros_Usuario(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComUsuarioParametro> parametrosUsuario = new List<ComUsuarioParametro>();
                ComUsuarioParametro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComUsuarioParametro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    parametrosUsuario.Add(row);
                }
                return parametrosUsuario;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public ComUsuario InformacionPersona(string Usuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Informacion_persona(@usuario);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("usuario", Usuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    ComUsuario informacion_persona = new ComUsuario();
                    informacion_persona.LlenadoDataNpgsql(lectorTablaSQL);
                    return informacion_persona;
                }
                else
                {
                    UsuarioExistenteException.UsuarioNoExistente();
                    return null;
                }
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public double SaldoMonedero(int IdUsuario)
        {
            double saldo;
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Saldo_Monedero(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                lectorTablaSQL.Read();
                saldo = lectorTablaSQL.GetDouble(0);
                return saldo;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return 0;
        }

        //Debe retornar el historial de operaciones
        public List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int IdTarjeta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Tarjetas(@tarjetaId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("tarjetaId", IdTarjeta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComOperacionTarjeta> operacionesTarjeta = new List<ComOperacionTarjeta>();
                ComOperacionTarjeta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComOperacionTarjeta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    operacionesTarjeta.Add(row);
                }
                return operacionesTarjeta;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        //Debe retornar el historial de operaciones
        public List<ComOperacionCuenta> HistorialOperacionesCuenta(int IdCuenta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Cuenta(@CuentaId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", IdCuenta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComOperacionCuenta> operacionesCuenta = new List<ComOperacionCuenta>();
                ComOperacionCuenta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComOperacionCuenta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    operacionesCuenta.Add(row);
                }
                return operacionesCuenta;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComOperacionMonedero> HistorialOperacionesMonedero(int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Monedero(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComOperacionMonedero> operacionesMonedero = new List<ComOperacionMonedero>();
                ComOperacionMonedero row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComOperacionMonedero();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    operacionesMonedero.Add(row);
                }
                return operacionesMonedero;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }
        //--------------------------------------------------------------------------------------

        //Operaciones de lógica-----------------------------------------------------------------
        public void RegistroUsuarioPersona(ComUsuario Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Usuario(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, " +
                    "@Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento, @Comision)");
                Formulario.LlenadoDataFormPersona(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al usuario", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al usuario", 201);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void RegistroUsuarioComercio(ComUsuario Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Usuario(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, " +
                    "@Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento, @Comision)");
                Formulario.LlenadoDataFormComercio(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al usuario", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al usuario", 201);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void RegistroComercio(ComComercio Formulario, int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Comercio(@Nombre, @Apellido, @RazonSocial, @IdUsuario, @Comision)");
                Formulario.LlenadoDataFormComercioReg(comandoSQL);
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar el comercio", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar el comercio", 201);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void RegistroCuenta(ComCuenta Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Cuenta(@UsuarioId, @TipoCuentaId, @BancoId, @Numero)");
                Formulario.LlenadoDataForm(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar la cuenta", 212);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la cuenta", 212);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void RegistroTarjeta(ComTarjeta Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Tarjeta(@UsuarioId, @TipoTarjetaId, @BancoId, @Numero, @FechaVencimiento, @cvc, @Estatus)");
                Formulario.LlenadoDataForm(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar la tarjeta", 211);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 211);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void EstablecerParametro(ComUsuarioParametro Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Establecer_Parametro(@UsuarioId, @ParametroId, @Validacion, @Estatus)");
                Formulario.LlenadoDataForm(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo establecer el parámetro", 210);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo establecer el parámetro", 210);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Cobro(int IdUsuarioCobrador, string IdUsuarioPaga, double Monto)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Cobro(@UsuarioId, @UsuarioACobrar, @Monto)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuarioCobrador));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioACobrar", IdUsuarioPaga));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar la solicitud de cobro", 209);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar la solicitud de cobro", 209);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Reintegro(int IdUsuarioCobrador, string IdUsuarioPaga, string Referencia)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro(@UsuarioId, @UsuarioACobrar, @Referencia)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuarioCobrador));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioACobrar", IdUsuarioPaga));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Referencia", Referencia));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar la solicitud de reintegro", 208);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar la solicitud de reintegro", 208);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void CancelarCobro(int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Cancelar_Cobro(@IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo cancelar el cobro", 207);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo cancelar el cobro", 207);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void CancelarReintegro(int IdReintegro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Cancelar_Reintegro(@IdReintegro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdReintegro", IdReintegro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo cancelar el reintegro", 206);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo cancelar el reintegro", 206);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void PagoTarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Tarjeta(@IdUsuarioReceptor, @IdTarjetaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjetaPago", IdTarjetaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el pago", 205);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el pago", 205);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void PagoCuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Cuenta(@IdUsuarioReceptor, @IdCuentaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuentaPago", IdCuentaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el pago", 205);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el pago", 205);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void PagoMonedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Monedero(@IdUsuarioReceptor, @IdUsuarioPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioPago", IdUsuarioPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el pago", 205);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el pago", 205);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void ReintegroTarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro_Tarjeta(@IdUsuarioReceptor, @IdTarjetaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjetaPago", IdTarjetaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el reintegro", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el reintegro", 201);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void ReintegroCuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro_Cuenta(@IdUsuarioReceptor, @IdCuentaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuentaPago", IdCuentaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el reintegro", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el reintegro", 201);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void ReintegroMonedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro_Monedero(@IdUsuarioReceptor, @IdUsuarioPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioPago", IdUsuarioPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el reintegro", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el reintegro", 201);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void ModificaciónUsuario(string Nombre, string Apellido, string Telefono, string Direccion, string RazonSocial, int EdoCivil, int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Modificación_Usuario(@nombre, @apellido, @telefono, @direccion, @razonSocial, @edoCivil, @IdUsuario)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("nombre", Nombre));
                comandoSQL.Parameters.Add(new NpgsqlParameter("apellido", Apellido));
                comandoSQL.Parameters.Add(new NpgsqlParameter("telefono", Telefono));
                comandoSQL.Parameters.Add(new NpgsqlParameter("direccion", Direccion));
                comandoSQL.Parameters.Add(new NpgsqlParameter("razonSocial", RazonSocial));
                comandoSQL.Parameters.Add(new NpgsqlParameter("edoCivil", EdoCivil));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo modificar al usuario", 202);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo modificar al usuario", 202);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public ComOperacionMonedero EjecutarCierre(int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Ejecutar_Cierre(@IdUsuario)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    ComOperacionMonedero operacion_monedero = new ComOperacionMonedero();
                    operacion_monedero.LlenadoDataCierreNpgsql(lectorTablaSQL);
                    return operacion_monedero;
                }
                else
                    throw new MoneyUcabException("No se pudo registrar el cierre", 204);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                throw ex;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public void EliminarCuenta(int IdCuenta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Eliminar_Cuenta(@CuentaId)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", IdCuenta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo eliminar la cuenta", 203);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo eliminar la cuenta", 203);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void EliminarTarjeta(int IdTarjeta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Eliminar_Tarjeta(@IdTarjeta)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjeta", IdTarjeta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo eliminar la tarjeta", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo eliminar la tarjeta", 204);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public bool ComercioUsuario(string Usuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Comercio_Usuario(@Usuario)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", Usuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    return lectorTablaSQL.GetBoolean(0);
                }
                else
                    throw new MoneyUcabException("No se pudo determinar qué tipo de usuario era", 220);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 0);
            }
            finally
            {
                Desconectar();
            }
            throw new MoneyUcabException("No se pudo determinar qué tipo de usuario era", 220);
        }

        public bool PersonaUsuario(string Usuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Persona_Usuario(@Usuario)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", Usuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    return lectorTablaSQL.GetBoolean(0);
                }
                else
                    throw new MoneyUcabException("No se pudo determinar qué tipo de usuario era", 220);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 0);
            }
            finally
            {
                Desconectar();
            }
            throw new MoneyUcabException("No se pudo determinar qué tipo de usuario era", 220);
        }

        public bool RecargaMonederoCuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Recarga_Monedero_Cuenta(@IdUsuarioReceptor, @IdCuentaPago, @Monto)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuentaPago", IdCuentaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    return lectorTablaSQL.GetBoolean(0);
                }
                else
                    throw new MoneyUcabException("No se pudo realizar la recarga", 240);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 0);
            }
            finally
            {
                Desconectar();
            }
            throw new MoneyUcabException("No se pudo realizar la recarga", 240);
        }

        public bool RecargaMonederoTarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Recarga_Monedero_Tarjeta(@IdUsuarioReceptor, @IdTarjetaPago, @Monto)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjetaPago", IdTarjetaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    return lectorTablaSQL.GetBoolean(0);
                }
                else
                    throw new MoneyUcabException("No se pudo realizar la recarga", 240);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 0);
            }
            finally
            {
                Desconectar();
            }
            throw new MoneyUcabException("No se pudo realizar la recarga", 240);
        }

        public List<ComUsuario> ConsultarUsuarios(string Query)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Consultar_Usuarios(@Query);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("Query", Query));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComUsuario> listaUsuarios = new List<ComUsuario>();
                ComUsuario row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComUsuario();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    listaUsuarios.Add(row);
                }
                return listaUsuarios;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public List<ComUsuario> ConsultarUsuariosFamiliares(int idUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Consultar_Usuario_Familiar(@idUsuario);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("idUsuario", idUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComUsuario> listaUsuarios = new List<ComUsuario>();
                ComUsuario row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComUsuario();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    listaUsuarios.Add(row);
                }
                return listaUsuarios;
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return null;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Eliminar_Usuario(@idUsuario);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("idUsuario", idUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    return lectorTablaSQL.GetBoolean(0);
                }
                else
                    throw new MoneyUcabException("No se pudo realizar la eliminación", 240);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return false;
        }

        public void RegistroUsuarioPersonaF(ComUsuario Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Usuario_F(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, " +
                    "@Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento, @IdUsuarioF, @Comision)");
                Formulario.LlenadoDataFormPersonaF(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al usuario familiar", 212);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al usuario familiar", 212);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void RegistroUsuarioComercioF(ComUsuario Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Usuario_F(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, " +
                    "@Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento, @IdUsuarioF, @Comision)");
                Formulario.LlenadoDataFormComercioF(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al usuario familiar", 212);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al usuario familiar", 212);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void EstablecerLimiteParametro(int IdParametro, string Limite)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Establecer_Limite_Parametro(@IdParametro, @Limite)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdParametro", IdParametro));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Limite", Limite));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo establecer límite parámetro", 211);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo establecer límite parámetro", 211);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void EstablecerComision(int IdComercio, double Comision)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Establecer_Comision(@IdComercio, @Comision)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdComercio", IdComercio));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Comision", Comision));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo establecer comision", 210);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo establecer comision", 210);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Retiro(int IdUsuario, int IdCuenta, double Monto)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Retiro(@IdUsuario, @IdCuenta, @Monto)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuenta", IdCuenta));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar retiro", 210);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar retiro", 210);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void BotonPagoCuenta(int IdUsuario, string UsuarioDestino, double Monto, int IdCuenta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Boton_Pago_Cuenta(@IdUsuario, @UsuarioDestino, @Monto, @IdCuenta)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioDestino", UsuarioDestino));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuenta", IdCuenta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar botón pago", 210);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar botón pago", 210);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void BotonPagoTarjeta(int IdUsuario, string UsuarioDestino, double Monto, int IdTarjeta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Boton_Pago_Tarjeta(@IdUsuario, @UsuarioDestino, @Monto, @IdTarjeta)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioDestino", UsuarioDestino));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjeta", IdTarjeta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar botón pago", 210);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar botón pago", 210);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void BotonPagoMonedero(int IdUsuario, string UsuarioDestino, double Monto)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Boton_Pago_Monedero(@IdUsuario, @UsuarioDestino, @Monto)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioDestino", UsuarioDestino));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar botón pago", 210);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar botón pago", 210);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void CambioEstatus(bool Reg, int IdOperacion, int Status)
        {
            try
            {
                string _status;
                Conectar();
                switch (Status)
                {
                    case(0): _status = "Solicitado";
                        break;
                    case(1): _status = "En Proceso";
                        break;
                    case(2): _status = "Completado";
                        break;
                    case(3): _status = "Cancelado";
                        break;
                    default: throw new MoneyUcabException("Status inexistente para cambiarlo en la operación", 250);
                }

                comandoSQL = conector.CreateCommand();
                comandoSQL.CommandText = string.Format("SELECT Cambio_Estatus_Op(@Reg, @IdOperacion, @Status)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("Reg", Reg));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdOperacion", IdOperacion));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Status", _status));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo cambiar status de operación", 250);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo cambiar status de operación", 250);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void PagoPaypal(bool Reg, int IdOperacion, string Referencia)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();
                comandoSQL.CommandText = string.Format("SELECT Pago_Paypal(@Reg, @IdOperacion, @Referencia)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("Reg", Reg));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdOperacion", IdOperacion));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Referencia", Referencia));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar el pago por PayPal", 251);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar el pago por PayPal", 251);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public void PagoStripe(bool Reg, int IdOperacion, string Referencia)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();
                comandoSQL.CommandText = string.Format("SELECT Pago_Stripe(@Reg, @IdOperacion, @Referencia)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("Reg", Reg));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdOperacion", IdOperacion));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Referencia", Referencia));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar el pago por PayPal", 251);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar el pago por PayPal", 251);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                PGSQLException.ProcesamientoException(ex);
            }
            catch (MoneyUcabException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
