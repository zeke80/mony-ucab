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
                Usuario = "TestUser" + userId,
                Email = "testuser" + +userId + "@gmail.com",
                Password = "TestUser" + +userId,
                IdTipoUsuario = idTipoUsuario,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = userId,
                Telefono = "telf-TestUser" + userId,
                Direccion = "dir-TestUser" + userId,
                Estatus = 1,
                Comercio = false,
                Nombre = "nom-TestUser" + userId,
                Apellido = "ape-TestUser" + userId,
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "raz-TestUser" + userId,
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
            dynamic infoPerosona = await APITest.informacion_persona(infoUser.Usuario,infoLogin);
            int idUsuario = infoPerosona.result.idUsuario;
            await APITest.EliminarUsuario(idUsuario);
        }
    }
}
