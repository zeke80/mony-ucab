
using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.LogicaDAO;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using NpgsqlTypes;

namespace moneyucab_portalweb_back.Comandos
{
    /// <summary>
    /// Clase que se encarga de la fábrica de los comandos simples para la lógica del backend, controlando de esta forma la instanciación y prolongación de vida de dichas clases.
    /// </summary>
    public static class FabricaComandos
    {

        /// <summary>
        /// Instanciación y fábrica del comando establecido con la lógica definida en sí mismo.
        /// </summary>
        /// <param name="UserManager">Es el administrador de acciones por parte del servidor a través del framework de entity.</param>
        /// <param name="Registration">Es el formulario usado para dicha acción dentro del comando.</param>
        /// <returns>Retorna la lógica de verificar registro de usuario.</returns>
        public static Comando_Verificar_Registro_Usuario Fabricar_Cmd_Verificar_Registro_Usuario(UserManager<Usuario> UserManager, RegistrationModel Registration)
        {
            return new Comando_Verificar_Registro_Usuario(UserManager, Registration);
        }

        public static Comando_Registro_Usuario Fabricar_Cmd_Registro_Usuario(UserManager<Usuario> UserManager, RegistrationModel Registration, ApplicationSettings AppSettings, IEmailSender EmailSender)
        {
            return new Comando_Registro_Usuario(UserManager, Registration, AppSettings, EmailSender);
        }

        public static Comando_Existencia_Usuario Fabricar_Cmd_Existencia_Usuario(UserManager<Usuario> UserManager, string Usuario, string Email, string IdUsuario)
        {
            return new Comando_Existencia_Usuario(UserManager, Usuario, Email, IdUsuario);
        }

        public static Comando_Inicio_Sesion Fabricar_Cmd_Inicio_Sesion(UserManager<Usuario> UserManager, LoginModel Registration, ApplicationSettings AppSettings, SignInManager<Usuario> SignInManager)
        {
            return new Comando_Inicio_Sesion(UserManager, Registration, AppSettings, SignInManager);
        }

        public static Comando_Verificar_Parametros Fabricar_Cmd_Verificar_Parametros(params string[] Parametros)
        {
            return new Comando_Verificar_Parametros(Parametros);
        }

        public static Comando_Confirmar_Email Fabricar_Cmd_Confirmar_Email(string IdUsuario, UserManager<Usuario> UserManager, ConfirmEmailModel UserModel)
        {
            return new Comando_Confirmar_Email(IdUsuario, UserManager, UserModel);
        }

        public static Comando_Olvido_Contraseña Fabricar_Cmd_Olvido_Contraseña(UserManager<Usuario> UserManager, ForgotPasswordModel Model, ApplicationSettings AppSettings, IEmailSender EmailSender)
        {
            return new Comando_Olvido_Contraseña(UserManager, Model, AppSettings, EmailSender);
        }

        public static Comando_Resetear_Password Fabricar_Cmd_Resetear_Password(UserManager<Usuario> UserManager, ResetPasswordModel Model)
        {
            return new Comando_Resetear_Password(UserManager, Model);
        }

        public static Comando_Verificar_Email_Confirmado Fabricar_Cmd_Verificar_Email_Confirmado(string Usuario, UserManager<Usuario> UserManager)
        {
            return new Comando_Verificar_Email_Confirmado(Usuario, UserManager);
        }

        public static Comando_Estados_Civiles Fabricar_Cmd_Estados_Civiles()
        {
            return new Comando_Estados_Civiles();
        }

        public static Comando_Tipos_Tarjetas Fabricar_Cmd_Tipos_Tarjetas()
        {
            return new Comando_Tipos_Tarjetas();
        }

        public static Comando_Bancos Fabricar_Cmd_Bancos()
        {
            return new Comando_Bancos();
        }

        public static Comando_Tipos_Cuentas Fabricar_Cmd_Tipos_Cuentas()
        {
            return new Comando_Tipos_Cuentas();
        }

        public static Comando_Tipos_Parametros Fabricar_Cmd_Tipos_Parametros()
        {
            return new Comando_Tipos_Parametros();
        }

        public static Comando_Frecuencias Fabricar_Cmd_Frecuencias()
        {
            return new Comando_Frecuencias();
        }

        public static Comando_Parametros Fabricar_Cmd_Parametros()
        {
            return new Comando_Parametros();
        }

        public static Comando_Tipos_Operaciones Fabricar_Cmd_Tipos_Operaciones()
        {
            return new Comando_Tipos_Operaciones();
        }

        public static Comando_Tipos_Identificaciones Fabricar_Cmd_Tipos_Identificaciones()
        {
            return new Comando_Tipos_Identificaciones();
        }

        public static Comando_Reintegros_Activos Fabricar_Cmd_Reintegros_Activos(int IdUsuario, int Solicitante)
        {
            return new Comando_Reintegros_Activos(IdUsuario, Solicitante);
        }

        public static Comando_Reintegros_Exitosos Fabricar_Cmd_Reintegros_Exitosos(int IdUsuario, int Solicitante)
        {
            return new Comando_Reintegros_Exitosos(IdUsuario, Solicitante);
        }

        public static Comando_Reintegros_Cancelados Fabricar_Cmd_Reintegros_Cancelados(int IdUsuario, int Solicitante)
        {
            return new Comando_Reintegros_Cancelados(IdUsuario, Solicitante);
        }

        public static Comando_Cobros_Activos Fabricar_Cmd_Cobros_Activos(int IdUsuario, int Solicitante)
        {
            return new Comando_Cobros_Activos(IdUsuario, Solicitante);
        }

        public static Comando_Cobros_Exitosos Fabricar_Cmd_Cobros_Exitosos(int IdUsuario, int Solicitante)
        {
            return new Comando_Cobros_Exitosos(IdUsuario, Solicitante);
        }

        public static Comando_Cobros_Cancelados Fabricar_Cmd_Cobros_Cancelados(int IdUsuario, int Solicitante)
        {
            return new Comando_Cobros_Cancelados(IdUsuario, Solicitante);
        }

        public static Comando_Tarjetas Fabricar_Cmd_Tarjetas(int IdUsuario)
        {
            return new Comando_Tarjetas(IdUsuario);
        }

        public static Comando_Cuentas Fabricar_Cmd_Cuentas(int IdUsuario)
        {
            return new Comando_Cuentas(IdUsuario);
        }

        public static Comando_Parametros_Usuario Fabricar_Cmd_Parametros_Usuario(int IdUsuario)
        {
            return new Comando_Parametros_Usuario(IdUsuario);
        }

        public static Comando_Verificar_Saldo Fabricar_Cmd_Verificar_Saldo(int IdUsuario)
        {
            return new Comando_Verificar_Saldo(IdUsuario);
        }

        public static Comando_Informacion_Persona Fabricar_Cmd_Informacion_Persona(string Usuario)
        {
            return new Comando_Informacion_Persona(Usuario);
        }

        public static Comando_Historial_Operaciones_Monedero Fabricar_Cmd_Hist_OpMonedero(int Usuario)
        {
            return new Comando_Historial_Operaciones_Monedero(Usuario);
        }

        public static Comando_Historial_Operaciones_Cuenta Fabricar_Cmd_Hist_OpCuenta(int IdCuenta)
        {
            return new Comando_Historial_Operaciones_Cuenta(IdCuenta);
        }

        public static Comando_Historial_Operaciones_Tarjeta Fabricar_Cmd_Hist_OpTarjeta(int IdTarjeta)
        {
            return new Comando_Historial_Operaciones_Tarjeta(IdTarjeta);
        }

        public static Comando_Registro_Usuario_DAO Fabricar_Cmd_Registro_Usuario_DAO(RegistrationModel Form)
        {
            return new Comando_Registro_Usuario_DAO(Form);
        }

        public static Comando_Realizar_Cobro Fabricar_Cmd_Realizar_Cobro(int IdUsuario, string Email, double Monto)
        {
            return new Comando_Realizar_Cobro(IdUsuario, Email, Monto);
        }

        public static Comando_Solicitar_Reintegro Fabricar_Cmd_Solicitar_Reintegro(int IdUsuario, string Email, string Referencia)
        {
            return new Comando_Solicitar_Reintegro(IdUsuario, Email, Referencia);
        }

        public static Comando_Cancelar_Cobro Fabricar_Cmd_Cancelar_Cobro(int IdUsuario)
        {
            return new Comando_Cancelar_Cobro(IdUsuario);
        }

        public static Comando_Cancelar_Reintegro Fabricar_Cmd_Cancelar_Reintegro(int IdUsuario)
        {
            return new Comando_Cancelar_Reintegro(IdUsuario);
        }

        public static Comando_Pago_Cuenta Fabricar_Cmd_Pago_Cuenta(int IdUsuarioReceptor, int IdMedioPaga, double Monto, int IdOperacion)
        {
            return new Comando_Pago_Cuenta(IdUsuarioReceptor, IdMedioPaga, Monto, IdOperacion);
        }

        public static Comando_Pago_Tarjeta Fabricar_Cmd_Pago_Tarjeta(int IdUsuarioReceptor, int IdMedioPaga, double Monto, int IdOperacion)
        {
            return new Comando_Pago_Tarjeta(IdUsuarioReceptor, IdMedioPaga, Monto, IdOperacion);
        }

        public static Comando_Pago_Monedero Fabricar_Cmd_Pago_Monedero(int IdUsuarioReceptor, int IdMedioPaga, double Monto, int IdOperacion)
        {
            return new Comando_Pago_Monedero(IdUsuarioReceptor, IdMedioPaga, Monto, IdOperacion);
        }

        public static Comando_Reintegro_Cuenta Fabricar_Cmd_Reintegro_Cuenta(int IdUsuarioReceptor, int IdMedioPaga, double Monto, int IdOperacion)
        {
            return new Comando_Reintegro_Cuenta(IdUsuarioReceptor, IdMedioPaga, Monto, IdOperacion);
        }

        public static Comando_Reintegro_Tarjeta Fabricar_Cmd_Reintegro_Tarjeta(int IdUsuarioReceptor, int IdMedioPaga, double Monto, int IdOperacion)
        {
            return new Comando_Reintegro_Tarjeta(IdUsuarioReceptor, IdMedioPaga, Monto, IdOperacion);
        }

        public static Comando_Reintegro_Monedero Fabricar_Cmd_Reintegro_Monedero(int IdUsuarioReceptor, int IdMedioPaga, double Monto, int IdOperacion)
        {
            return new Comando_Reintegro_Monedero(IdUsuarioReceptor, IdMedioPaga, Monto, IdOperacion);
        }

        public static Comando_Modificacion_Usuario Fabricar_Cmd_Modificar_Usuario(string Nombre, string Apellido, string Telefono, string Direccion, string RazonSocial, int idEstadoCivil,  int IdUsuario)
        {
            return new Comando_Modificacion_Usuario(Nombre, Apellido, Telefono, Direccion, RazonSocial, idEstadoCivil, IdUsuario);
        }

        public static Comando_Ejecutar_Cierre Fabricar_Cmd_Ejecutar_Cierre(int IdUsuario)
        {
            return new Comando_Ejecutar_Cierre(IdUsuario);
        }

        public static Comando_Eliminar_Billetera_Cuenta Fabricar_Cmd_Eliminar_Cuenta(int IdUsuario)
        {
            return new Comando_Eliminar_Billetera_Cuenta(IdUsuario);
        }

        public static Comando_Eliminar_Billetera_Tarjeta Fabricar_Cmd_Eliminar_Tarjeta(int IdUsuario)
        {
            return new Comando_Eliminar_Billetera_Tarjeta(IdUsuario);
        }

        public static Comando_Registrar_Billetera_Tarjeta Fabricar_Cmd_Registrar_Tarjeta(int IdUsuario, int IdTipoTarjeta, int IdBanco, long Numero, NpgsqlDate FechaVencimiento, int CVC, int Estatus)
        {
            return new Comando_Registrar_Billetera_Tarjeta(IdUsuario, IdTipoTarjeta, IdBanco, Numero, FechaVencimiento, CVC, Estatus);
        }

        public static Comando_Registrar_Billetera_Cuenta Fabricar_Cmd_Registrar_Cuenta(int IdUsuario, int IdTipoCuenta, int IdBanco, string Numero)
        {
            return new Comando_Registrar_Billetera_Cuenta(IdUsuario, IdTipoCuenta, IdBanco, Numero);
        }

        public static Comando_Establecer_Parametro Fabricar_Cmd_Establecer_Parametro(int IdUsuario, int IdParametro, string Validacion, int Estatus)
        {
            return new Comando_Establecer_Parametro(IdUsuario, IdParametro, Validacion, Estatus);
        }

        public static Comando_Verificar_Autenticacion Fabricar_Cmd_Verificar_Autenticacion(UserManager<Usuario> UserManager, LoginModel Model)
        {
            return new Comando_Verificar_Autenticacion(UserManager, Model);
        }

        public static Comando_Comercio_Usuario Fabricar_Cmd_Comercio_Usuario(string Usuario)
        {
            return new Comando_Comercio_Usuario(Usuario);
        }

        public static Comando_Persona_Usuario Fabricar_Cmd_Persona_Usuario(string Usuario)
        {
            return new Comando_Persona_Usuario(Usuario);
        }

        public static Comando_Verificar_Registro_Comercio Fabricar_Cmd_Verificar_Registro_Comercio(UserManager<Usuario> UserManager, ComercioForm Comercio)
        {
            return new Comando_Verificar_Registro_Comercio(UserManager, Comercio);
        }

        public static Comando_Registro_Comercio Fabricar_Cmd_Registro_Comercio(ComercioForm Comercio)
        {
            return new Comando_Registro_Comercio(Comercio);
        }

        public static Comando_Recarga_Monedero_Cuenta Fabricar_Cmd_Recarga_Monedero_Cuenta(int IdUsuario, int IdMedioPaga, double Monto)
        {
            return new Comando_Recarga_Monedero_Cuenta(IdUsuario, IdMedioPaga, Monto);
        }

        public static Comando_Recarga_Monedero_Tarjeta Fabricar_Cmd_Recarga_Monedero_Tarjeta(int IdUsuario, int IdMedioPaga, double Monto)
        {
            return new Comando_Recarga_Monedero_Tarjeta(IdUsuario, IdMedioPaga, Monto);
        }
        
        public static Comando_Cambio_Contraseña Fabricar_Cmd_Cambio_Contraseña(UserManager<Usuario> UserManager, string Usuario, string PasswordActual, string PasswordCambio)
        {
            return new Comando_Cambio_Contraseña(UserManager, Usuario, PasswordActual, PasswordCambio);
        }

        public static Comando_Consultar_Usuarios Fabricar_Cmd_Consultar_Usuarios(string Query)
        {
            return new Comando_Consultar_Usuarios(Query);
        }

        public static Comando_Consultar_Usuarios_Familiares Fabricar_Cmd_Consultar_Usuarios_Familiares(int idUsuario)
        {
            return new Comando_Consultar_Usuarios_Familiares(idUsuario);
        }

        public static Comando_Eliminar_Usuario Fabricar_Cmd_Eliminar_Usuario(int idUsuario)
        {
            return new Comando_Eliminar_Usuario(idUsuario);
        }

        public static Comando_Registro_Usuario_Familiar Fabricar_Cmd_Registro_Usuario_Familiar(UserManager<Usuario> UserManager, RegistrationModel Registration, ApplicationSettings AppSettings, IEmailSender EmailSender)
        {
            return new Comando_Registro_Usuario_Familiar(UserManager, Registration, AppSettings, EmailSender);
        }

        public static Comando_Registro_Usuario_Familiar_DAO Fabricar_Cmd_Registro_Usuario_Familiar_DAO(RegistrationModel Form)
        {
            return new Comando_Registro_Usuario_Familiar_DAO(Form);
        }

        public static Comando_Establecer_Limite_Parametro Fabricar_Cmd_Establecer_Limite_Parametro(int IdUsuario, string Limite)
        {
            return new Comando_Establecer_Limite_Parametro(IdUsuario, Limite);
        }

        public static Comando_Establecer_Comision Fabricar_Cmd_Establecer_Comision(int IdComercio, double Comision)
        {
            return new Comando_Establecer_Comision(IdComercio, Comision);
        }

        public static Comando_Retiro Fabricar_Cmd_Retiro(int IdUsuario, int IdCuenta, double Monto)
        {
            return new Comando_Retiro(IdUsuario, IdCuenta, Monto);
        }

        public static Comando_Boton_Pago_Cuenta Fabricar_Cmd_Boton_Pago_Cuenta(int IdUsuario, string UsuarioDestino, double Monto, int IdCuenta)
        {
            return new Comando_Boton_Pago_Cuenta(IdUsuario, UsuarioDestino, Monto, IdCuenta);
        }

        public static Comando_Boton_Pago_Tarjeta Fabricar_Cmd_Boton_Pago_Tarjeta(int IdUsuario, string UsuarioDestino, double Monto, int IdTarjeta)
        {
            return new Comando_Boton_Pago_Tarjeta(IdUsuario, UsuarioDestino, Monto, IdTarjeta);
        }

        public static Comando_Boton_Pago_Monedero Fabricar_Cmd_Boton_Pago_Monedero(int IdUsuario, string UsuarioDestino, double Monto)
        {
            return new Comando_Boton_Pago_Monedero(IdUsuario, UsuarioDestino, Monto);
        }
    }
}
