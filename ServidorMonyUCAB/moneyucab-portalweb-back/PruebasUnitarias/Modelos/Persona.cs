using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Modelos
{
    class Persona
    {
        string usuario;
        string email;
        string password;
        int idTipoUsuario;
        int idTipoIdentificacion;
        int idEstadoCivil;
        int anoRegistro;
        int mesRegistro;
        int diaRegistro;
        int nroIdentificacion;
        string telefono;
        string direccion;
        int estatus;
        bool comercio;
        string nombre;
        string apellido;
        int anoNacimiento;
        int mesNacimiento;
        int diaNacimiento;
        string razonSocial;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int IdTipoUsuario { get => idTipoUsuario; set => idTipoUsuario = value; }
        public int IdTipoIdentificacion { get => idTipoIdentificacion; set => idTipoIdentificacion = value; }
        public int IdEstadoCivil { get => idEstadoCivil; set => idEstadoCivil = value; }
        public int AnoRegistro { get => anoRegistro; set => anoRegistro = value; }
        public int MesRegistro { get => mesRegistro; set => mesRegistro = value; }
        public int DiaRegistro { get => diaRegistro; set => diaRegistro = value; }
        public int NroIdentificacion { get => nroIdentificacion; set => nroIdentificacion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public bool Comercio { get => comercio; set => comercio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int AnoNacimiento { get => anoNacimiento; set => anoNacimiento = value; }
        public int MesNacimiento { get => mesNacimiento; set => mesNacimiento = value; }
        public int DiaNacimiento { get => diaNacimiento; set => diaNacimiento = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
    }
}

