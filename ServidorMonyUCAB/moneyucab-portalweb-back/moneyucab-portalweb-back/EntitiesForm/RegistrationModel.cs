using Comunes.Comun;
using NpgsqlTypes;
using System;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class RegistrationModel : LoginModel
    {
        public int idTipoUsuario { get; set; }
        public int idUsuarioF { get; set; }
        public int idTipoIdentificacion { get; set; }
        public int idEstadoCivil { get; set; }
        public int anoRegistro { get; set; }
        public int mesRegistro { get; set; }
        public int diaRegistro { get; set; }
        public int nroIdentificacion { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int estatus { get; set; }
        public Boolean comercio { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int anoNacimiento { get; set; }
        public int mesNacimiento { get; set; }
        public int diaNacimiento { get; set; }
        public string razonSocial { get; set; }
        public double comision { get; set; }


        public ComUsuario Formatear_Formulario()
        {
            if (this.comercio)
            {
                ComComercio comercio_reg = new ComComercio(razonSocial, nombre, apellido, comision);
                ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion(idTipoIdentificacion, 'v', "", 1);
                ComUsuario UsuarioRetorn = new ComUsuario(comercio_reg, null, tipoIdentificacion, 0, "", usuario, new NpgsqlDate(anoRegistro, mesRegistro, diaRegistro), nroIdentificacion, email, telefono, direccion, 1, password, idUsuarioF);
                return UsuarioRetorn;
            }
            else
            {
                ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion(idTipoIdentificacion, 'v', "", 1);
                ComEstadoCivil estadoCivil = new ComEstadoCivil(idEstadoCivil, "", 's', 1);
                ComPersona persona = new ComPersona(estadoCivil, nombre, apellido, new NpgsqlDate(anoNacimiento, mesNacimiento, diaNacimiento));
                ComUsuario UsuarioRetorn = new ComUsuario(null, persona, tipoIdentificacion, 0, "", usuario, new NpgsqlDate(anoRegistro, mesRegistro, diaRegistro), nroIdentificacion, email, telefono, direccion, 1, password, idUsuarioF);
                return UsuarioRetorn;
            }
        }
        
    }
}
