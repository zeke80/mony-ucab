using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común que establece el uso de billetera tarjeta en vinculación con un usuario.
    /// </summary>
    public class ComTarjeta : EntidadComun, IEntidadComun, IFormularioInsert
    {
        /// <summary>
        /// Establece el tipo de tarjeta sobre la entidad de tarjeta.
        /// </summary>
        public ComTipoTarjeta tipoTarjeta = new ComTipoTarjeta();
        /// <summary>
        /// Establece la fuente de banco relacionado con una tarjeta.
        /// </summary>
        public ComBanco banco = new ComBanco();
        /// <summary>
        /// Identificador único relacionado directamente con la tarjeta dentro de la aplicación.
        /// </summary>
        public int idTarjeta { get; set; }
        /// <summary>
        /// Identificador del usuario propietario de dicha tarjeta.
        /// </summary>
        public int idUsuario { get; set; }
        /// <summary>
        /// Numero que identifica funciones de la tarjeta dentro de la entidad bancaria.
        /// </summary>
        public long numero { get; set; }
        /// <summary>
        /// Establece la fecha de vencimiento de la tarjeta dentro de la entidad bancaria.
        /// </summary>
        public NpgsqlDate fechaVencimiento { get; set; }
        /// <summary>
        /// Establece el código de seguridad para operaciones de dicha tarjeta.
        /// </summary>
        public int cvc { get; set; }
        /// <summary>
        /// Estatus de uso para dicha tarjeta dentro de la aplicación.
        /// </summary>
        public int estatus { get; set; }

        public ComTarjeta()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="TipoTarjeta">Establece el tipo de tarjeta relacionado a la tarjeta determinada.</param>
        /// <param name="Banco">Establece la entidad bancaria vinculada con la tarjeta.</param>
        /// <param name="IdUsuario">Establece el identificador del usuario propietario de dicha tarjeta.</param>
        /// <param name="Numero">Identificador de la tarjeta dentro de la entidad bancaria.</param>
        /// <param name="FechaVencimiento">Establece la fecha de vencimiento de dicha tarjeta dentro de la entidad bancaria.</param>
        /// <param name="Cvc">Establece el código de seguridad para la tarjeta.</param>
        /// <param name="Estatus">Estatus de uso para dicha tarjeta dentro de la aplicación</param>
        public ComTarjeta(ComTipoTarjeta Tipotarjeta, ComBanco Banco, int IdUsuario, long Numero, NpgsqlDate FechaVencimiento, int Cvc, int Estatus)
        {
            this.tipoTarjeta = Tipotarjeta;
            this.banco = Banco;
            this.idUsuario = IdUsuario;
            this.numero = Numero;
            this.fechaVencimiento = FechaVencimiento;
            this.cvc = Cvc;
            this.estatus = Estatus;
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this.idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoTarjetaId", this.tipoTarjeta.idTipoTarjeta));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("BancoId", this.banco.idBanco));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Numero", this.numero));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaVencimiento", this.fechaVencimiento));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("cvc", this.cvc));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.tipoTarjeta.offset = 11;
            this.tipoTarjeta.LlenadoDataNpgsql(Data);
            this.banco.offset = 8;
            this.banco.LlenadoDataNpgsql(Data);
            this.idTarjeta = Data.GetInt32(0 + offset);
            this.idUsuario = Data.GetInt32(1 + offset);
            this.numero = Data.GetInt64(4 + offset);
            this.fechaVencimiento = Data.GetDate(5);
            this.cvc = Data.GetInt32(6 + offset);
            this.estatus = Data.GetInt32(7 + offset);
        }
    }
}
