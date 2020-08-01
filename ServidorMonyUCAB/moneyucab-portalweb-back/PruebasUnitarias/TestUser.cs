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
        int userId;
        Login infoLogin;

        public TestUser(int userId, int idTipoUsuario)
        {
            this.userId = userId;
            infoUser = new Persona
            {
                Usuario = "testuser1" + userId,
                Email = "testuser1" + userId + "@gmail.com",
                Password = "testuser1",
                IdTipoUsuario = 3,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 2222,
                Telefono = "testuser1",
                Direccion = "testuser1",
                Estatus = 1,
                Comercio = false,
                Nombre = "testuser1",
                Apellido = "testuser1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "testuser1",
            };

            infoLogin = new Login
            {
                UserName = infoUser.Usuario,
                Email = infoUser.Email,
                Password = infoUser.Password,
                Comercio = infoUser.Comercio,
            };
        }

        public string getUsername()
        {
            return infoUser.Usuario;
        }

        public Login getInfoLogin()
        {
            return infoLogin;
        }

        public async Task<HttpResponseMessage> registrar()
        {
            return await APITest.register(infoUser);
        }

        public async void login()
        {
            await APITest.login(infoLogin);
        }

        public async void eliminar()
        {
            dynamic infoPerosona = await APITest.InformacionPersona(infoUser.Usuario,infoLogin);
            int idUsuario = infoPerosona.result.idUsuario;
            await APITest.EliminarUsuario(idUsuario);
        }
    }
}
