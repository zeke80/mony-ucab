using Comunes.Comun;
using System;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    /// <summary>
    /// Interface <c>IDAOLogin</c>
    /// Interfaz que establece los métodos que deben implementar cualquier dao para realizar los distintos ingresos en l sistema.
    /// </summary>
    public interface IDAOLogic
    {
        /// <summary>
        /// Realiza la consulta con base de datos de los estados civiles disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los estados civiles posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComEstadoCivil> EstadosCiviles();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de tarjeta disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de tarjeta posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoTarjeta> TiposTarjeta();

        /// <summary>
        /// Realiza la consulta con base de datos de los bancos disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los bancos posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComBanco> Bancos();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de cuentas disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de cuentas posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoCuenta> TiposCuentas();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de parametro disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de parametro posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoParametro> TiposParametros();

        /// <summary>
        /// Realiza la consulta con base de datos de las frecuencias disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de las frecuencias posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComFrecuencia> Frecuencias();

        /// <summary>
        /// Realiza la consulta con base de datos de los parametros disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los parametros posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComParametro> Parametros();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de operaciones disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de operaciones posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoOperacion> TiposOperaciones();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de identificaciones disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de identificaciones posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoIdentificacion> TiposIdentificaciones();

        /// <summary>
        /// Realiza la consulta con base de datos de las tarjetas disponibles en la lógica de negocio de un usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de las tarjetas que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTarjeta> Tarjetas(int IdUsuario);

        /// <summary>
        /// Realiza la consulta con base de datos de las cuentas que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de las cuentas que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComCuenta> Cuentas(int IdUsuario);

        /// <summary>
        /// Realiza la consulta con base de datos de los reintegros activos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los reintegros activos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComReintegro> ReintegrosActivos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los reintegros cancelados que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los reintegros cancelados que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComReintegro> ReintegrosCancelados(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los reintegros exitosos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los reintegros exitosos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComReintegro> ReintegrosExitosos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los cobros activos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los cobros activos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComPago> CobrosActivos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los cobros cancelados que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los cobros cancelados que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComPago> CobrosCancelados(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los cobros exitosos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los cobros exitosos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComPago> CobrosExitosos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los parametros que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los parametros que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComUsuarioParametro> ParametrosUsuario(int UsuarioId);


        /// <summary>
        /// Realiza la consulta con base de datos de la información que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho usuario
        /// </returns>
        /// <param name="Usuario">Nombre del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        ComUsuario InformacionPersona(string Usuario);

        /// <summary>
        /// Realiza la consulta con base de datos del saldo que posee dicho usuario sobre su monedero.
        /// </summary>
        /// <returns>
        /// Entrega el saldo de monedero que contiene el usuario
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        double SaldoMonedero(int IdUsuario);

        /// <summary>
        /// Realiza la consulta con base de datos del historial de operaciones sobre el medio indicado.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho medio (billetera)
        /// </returns>
        /// <param name="IdTarjeta">Id de la tarjeta a la que se consultará su historial de operaciones.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int IdTarjeta);

        /// <summary>
        /// Realiza la consulta con base de datos del historial de operaciones sobre el medio indicado.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho medio (billetera)
        /// </returns>
        /// <param name="IdCuenta">Id de la cuenta a la que se consultará su historial de operaciones.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComOperacionCuenta> HistorialOperacionesCuenta(int IdCuenta);

        /// <summary>
        /// Realiza la consulta con base de datos del historial de operaciones sobre el medio indicado.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho medio (billetera)
        /// </returns>
        /// <param name="IdUsuario">Id del usuario a la que se consultará su historial de operaciones a través de su monedero.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComOperacionMonedero> HistorialOperacionesMonedero(int IdUsuario);

        /// <summary>
        /// Realiza el registro de un usuario como persona dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroUsuarioPersona(ComUsuario Formulario);

        /// <summary>
        /// Realiza el registro de un usuario como comercio dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroUsuarioComercio(ComUsuario Formulario);

        /// <summary>
        /// Realiza el registro de un comercio a un usuario existente.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <param name="IdUsuario">Id del usuario al cual se le realizará el registro de comercio.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroComercio(ComComercio Formulario, int IdUsuario);

        /// <summary>
        /// Realiza el registro de una cuenta como billetera dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroCuenta(ComCuenta Formulario);

        /// <summary>
        /// Realiza el registro de una tarjeta como billetera dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroTarjeta(ComTarjeta Formulario);

        /// <summary>
        /// Establecer el parametro personalizado para el usuario.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void EstablecerParametro(ComUsuarioParametro Formulario);

        /// <summary>
        /// Realiza la solicitud de cobro a un usuario especificando el monto determinado.
        /// </summary>
        /// <param name="IdUsuarioCobrador">Especifica el id del usuario que cobra.</param>
        /// <param name="UsuarioPaga">Especifica el nombre del usuario que debe realiazr el pago.</param>
        /// <param name="monto">Especifica el monto por el cual se cobra al usuario.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void Cobro(int IdUsuarioCobrador, string UsuarioPaga, double Monto);

        /// <summary>
        /// Realiza la solicitud de cobro a un usuario especificando el monto determinado.
        /// </summary>
        /// <param name="IdUsuarioCobrador">Especifica el id del usuario que solicita el reintegro.</param>
        /// <param name="UsuarioPaga">Especifica el nombre del usuario que debe realizar el pago del reintegro.</param>
        /// <param name="Referencia">Especifica la referencia que establece sobre qué operación se solicita reintegro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void Reintegro(int IdUsuarioCobrador, string UsuarioPaga, string Referencia);

        /// <summary>
        /// Cancela el cobro solicitado al usuario.
        /// </summary>
        /// <param name="IdCobro">Especifica el id del cobro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void CancelarCobro(int IdCobro);

        /// <summary>
        /// Cancela el reintegro solicitado al usuario.
        /// </summary>
        /// <param name="IdCobro">Especifica el id del reintegro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void CancelarReintegro(int IdReintegro);

        /// <summary>
        /// Se realiza un pago con la tarjeta.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor del pago</param>
        /// <param name="IdTarjetaPago">Especifica el id de la tarjeta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto del pago</param>
        /// <param name="IdCobro">Especifica el id del cobro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void PagoTarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro);

        /// <summary>
        /// Se realiza un pago con la cuenta.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor del pago</param>
        /// <param name="IdCuentaPago">Especifica el id de la cuenta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto del pago</param>
        /// <param name="IdCobro">Especifica el id del cobro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void PagoCuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro);

        /// <summary>
        /// Se realiza un pago con el monedero.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor del pago</param>
        /// <param name="IdUsuarioPago">Especifica el id del usuario que realiza el pago</param>
        /// <param name="Monto">Especifica el monto del pago</param>
        /// <param name="IdCobro">Especifica el id del cobro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void PagoMonedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro);

        /// <summary>
        /// Se realiza un reintegro con la tarjeta.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor del pago</param>
        /// <param name="IdTarjetaPago">Especifica el id de la tarjeta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto del pago</param>
        /// <param name="IdCobro">Especifica el id del reintegro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void ReintegroTarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro);

        /// <summary>
        /// Se realiza un reintegro con la cuenta.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor del pago</param>
        /// <param name="IdCuentaPago">Especifica el id de la cuenta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto del pago</param>
        /// <param name="IdCobro">Especifica el id del reintegro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void ReintegroCuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro);

        /// <summary>
        /// Se realiza un pago con el monedero.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor del pago</param>
        /// <param name="IdCuentaPago">Especifica el id de la cuenta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto del pago</param>
        /// <param name="IdCobro">Especifica el id del reintegro solicitado</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void ReintegroMonedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro);

        /// <summary>
        /// Se realiza una recarga con la cuenta.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor de la recarga</param>
        /// <param name="IdCuentaPago">Especifica el id de la cuenta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto de la recarga</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        bool RecargaMonederoCuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto);

        /// <summary>
        /// Se realiza una recarga con la tarjeta.
        /// </summary>
        /// <param name="IdUsuarioReceptor">Especifica el id del usuario receptor de la recarga</param>
        /// <param name="IdTarjetaPago">Especifica el id de la tarjeta que realiza el pago</param>
        /// <param name="Monto">Especifica el monto de la recarga</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        bool RecargaMonederoTarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto);

        /// <summary>
        /// Se realiza la edición de datos con los parámetros colocados para dicho usuario, sin embargo, usuario e email no funcionan como edición.
        /// </summary>
        /// <param name="Nombre">Especifica el nombre de usuario para la aplicación</param>
        /// <param name="Apellido">Especifica el apellido que usa el usuario para la aplicación</param>
        /// <param name="Telefono">Especifica el teléfono que usa el usuario</param>
        /// <param name="Direccion">Especifica la dirección del usuario</param>
        /// <param name="RazonSocial">Especifica la razonSocial del usuario</param>
        /// <param name="EdoCivil">Especifica el id del estado civil del usuario</param>
        /// <param name="IdUsuario">Especifica el id del usuario a realizar edición de datos</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void ModificaciónUsuario(string Nombre, string Apellido, string Telefono, string Direccion, string RazonSocial, int EdoCivil, int IdUsuario);

        /// <deprecated>
        /// <summary>
        /// Se realiza la ejecución del cierre para el usuario determinado
        /// </summary>
        /// <returns>Retorna el resumen de ejecución de cierre </returns>
        /// <param name="IdUsuario">Especifica el id del usuario que ejecuta el cierre</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception></deprecated>
        ComOperacionMonedero EjecutarCierre(int IdUsuario);


        /// <deprecated>
        /// <summary>
        /// Se realiza la eliminación de la cuenta determinada (Deprecated)
        /// </summary>
        /// <param name="IdCuenta">Especifica el id de la cuenta a eliminar</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception></deprecated>
        void EliminarCuenta(int IdCuenta);

        /// <summary>
        /// Se realiza la eliminación de la tarjeta determinada
        /// </summary>
        /// <param name="IdTarjeta">Especifica el id de la cuenta a eliminar</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void EliminarTarjeta(int IdTarjeta);

        /// <summary>
        /// Se pregunta si el usuario es un comercio.
        /// </summary>
        /// <param name="Usuario">Especifica el nombre de usuario a interrogar información</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        Boolean ComercioUsuario(string Usuario);

        /// <summary>
        /// Se pregunta si el usuario es un comercio.
        /// </summary>
        /// <param name="Usuario">Especifica el nombre de usuario a interrogar información</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        Boolean PersonaUsuario(string Usuario);

        /// <summary>
        /// Se realiza una consulta de todos los usuarios dentro de la base de datos.
        /// </summary>
        /// <param name="Query">Especifica el query a usar para consultar a los usuarios</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComUsuario> ConsultarUsuarios(string Query);

        /// <summary>
        /// Se realiza una consulta de todos los usuarios vinculados familiarmente con el indicado.
        /// </summary>
        /// <param name="idUsuario">Especifica el id del usuariop relacionados directamente al usuario indicado.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComUsuario> ConsultarUsuariosFamiliares(int idUsuario);

        /// <summary>
        /// Se realiza una eliminación de usuario en base de datos.
        /// </summary>
        /// <param name="idUsuario">Especifica el id del usuario para inhabilitarlo (eliminarlo).</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        bool EliminarUsuario(int idUsuario);

        /// <summary>
        /// Realiza el registro de un usuario como persona dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroUsuarioPersonaF(ComUsuario Formulario);

        /// <summary>
        /// Realiza el registro de un usuario como comercio dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroUsuarioComercioF(ComUsuario Formulario);
    }
}