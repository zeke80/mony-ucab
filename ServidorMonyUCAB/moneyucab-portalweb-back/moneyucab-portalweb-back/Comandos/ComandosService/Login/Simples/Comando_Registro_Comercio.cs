using Comandos;
using DAO;
using Excepciones;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Registro_Comercio : Comando<Object>
    {

        private ComercioForm _comercio;


        public Comando_Registro_Comercio(ComercioForm Comercio)
        {
            this._comercio = Comercio;
        }

        async public Task<bool> Ejecutar()
        {
            DAOBase dao = new DAOBase();
            dao.RegistroComercio(_comercio.Formatear_Formulario(), _comercio.idUsuario);
            return true;
        }

    }
}
