using Npgsql;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común Cuenta vinculados directamente a la entidad común para sus respectivas acciones dentro de la aplicación y manejo de formularios.
    /// </summary>
    [DataContract]
    public class ComCuenta : EntidadComun, IEntidadComun, IFormularioInsert
    {
        /// <summary>
        /// Establece el tipo de cuenta al cual está vinculada esta entidad.
        /// </summary>
        [DataMember]
        public ComTipoCuenta _tipoCuenta = new ComTipoCuenta();
        /// <summary>
        /// Entidad al cual hace rteferencia el origen de dicha cuenta dentro de la aplicación.
        /// </summary>
        [DataMember]
        public ComBanco _banco = new ComBanco();
        /// <summary>
        /// Identificador único para la cuenta establecido a través de la base de datos
        /// </summary>
        [DataMember]
        public int _idCuenta { get; set; }
        /// <summary>
        /// Identificador único para el usuario que posee la cuenta.
        /// </summary>
        [DataMember]
        public int _idUsuario { get; set; }
        /// <summary>
        /// Identificador que establece la cuenta respecto al banco relacionado.
        /// </summary>
        [DataMember]
        public string _numero { get; set; }

        public ComCuenta()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="TipoCuenta">Establece el tipo de cuenta al cual está vinculada esta entidad.</param>
        /// <param name="Banco">Entidad al cual hace rteferencia el origen de dicha cuenta dentro de la aplicación.</param>
        /// <param name="IdUsuario">Identificador único para el usuario que posee la cuenta.</param>
        /// <param name="Numero">Identificador que establece la cuenta respecto al banco relacionado.</param>
        public ComCuenta(ComTipoCuenta TipoCuenta, ComBanco Banco, int IdUsuario, string Numero)
        {
            this._tipoCuenta = TipoCuenta;
            this._banco = Banco;
            this._idUsuario = IdUsuario;
            this._numero = Numero;
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this._idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoCuentaId", this._tipoCuenta.idTipoCuenta));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("BancoId", this._banco.idBanco));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Numero", this._numero));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this._tipoCuenta.offset = 8;
            this._tipoCuenta.LlenadoDataNpgsql(Data);
            this._banco.offset = 5;
            this._banco.LlenadoDataNpgsql(Data);
            this._idCuenta = Data.GetInt32(0);
            this._idUsuario = Data.GetInt32(1);
            this._numero = Data.GetString(4);
        }
    }
}
