using PruebasUnitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    class TestUser
    {
        Persona infoUser;
        string token;

        public TestUser(int userId, int idTipoUsuario)
        {
            /*listaCuentas = new List<Cuenta>();
            listaTarjetas = new List<Tarjeta>();*/
            infoUser = new Persona
            {
                usuario = "TestUser1",
                email = "testuser1@gmail.com",
                password = "PassTestUser1",
                idTipoUsuario = 3,
                idTipoIdentificacion = 1,
                idEstadoCivil = 1,
                anoRegistro = 2000,
                mesRegistro = 1,
                diaRegistro = 1,
                nroIdentificacion = 1,
                telefono = "",
                direccion = "",
                estatus = 1,
                comercio = false,
                nombre = "",
                apellido = "",
                anoNacimiento = 2000,
                mesNacimiento = 1,
                diaNacimiento = 1,
                razonSocial = "",
            };
        }

        public dynamic getInfoLogin()
        {
            dynamic infoLogin = new
            {
                infoUser.usuario,
                infoUser.email,
                infoUser.password,
                infoUser.comercio,
            };
            return infoLogin;
        }

        public void login()
        {
            dynamic res = APITest.login(getInfoLogin());
            token = res.Result.Content.result.token;
            infoUser.idusuario = res.Result.Content.result.userID;
        }

        /*public List<Cuenta> getCuentas()
        {
            var listaCuentas = new List<Cuenta>();
            
        }*/
    }
}
