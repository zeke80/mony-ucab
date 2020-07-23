using Comunes.Comun;
using DAO;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private UserManager<Usuario> _userManager;

        public AdminController(UserManager<Usuario> UserManager)
        {
            _userManager = UserManager;
        }

        //Operaciones de consulta---------------------------------------------------------------
        [HttpPost]
        [Route("ConsultaUsuarios")]
        //Post: /api/Authentication/Register
        public async Task<Object> ConsultarUsuarios([FromQuery]string Query)
        {
            try
            {
                return await FabricaComandos.Fabricar_Cmd_Consultar_Usuarios(Query).Ejecutar();
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpPost]
        [Route("EliminarUsuario")]
        //Post: /api/Authentication/Register
        public async Task<Object> EliminarUsuario([FromQuery] int idUsuario)
        {
            try
            {
                return await FabricaComandos.Fabricar_Cmd_Eliminar_Usuario(idUsuario).Ejecutar();
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

    }
}