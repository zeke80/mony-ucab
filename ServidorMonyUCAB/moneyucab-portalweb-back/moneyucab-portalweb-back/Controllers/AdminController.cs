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
using moneyucab_portalweb_back.Services.Middleware.ActionFilter;

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
        [ServiceFilter(typeof(AdminFilter))]
        [HttpGet]
        [Authorize]
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

        [ServiceFilter(typeof(AdminFilter))]
        [HttpDelete]
        [Authorize]
        [Route("EliminarUsuario")]
        //Post: /api/Authentication/Register
        public async Task<Object> EliminarUsuario([FromQuery] int idUsuario)
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Eliminar_Usuario(idUsuario).Ejecutar();
                return Ok(new { key = "EliminacionUsuario", message = "Usuario eliminado.", result });
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

        [ServiceFilter(typeof(AdminFilter))]
        [HttpPost]
        [Authorize]
        [Route("EstablecerLimiteParametro")]
        //Post: /api/Authentication/Register
        public async Task<Object> EstablecerLimiteParametro([FromQuery] EstLimParam formulario)
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Establecer_Limite_Parametro(formulario.idParametro, formulario.limite).Ejecutar();
                return Ok(new { key = "LimiteParametro", message = "Limite establecido.", result });
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

        [ServiceFilter(typeof(AdminFilter))]
        [HttpPost]
        [Authorize]
        [Route("EstablecerComision")]
        //Post: /api/Authentication/Register
        public async Task<Object> EstablecerComision([FromQuery] EstComision formulario)
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Establecer_Comision(formulario.idComercio, formulario.comision).Ejecutar();
                return Ok(new { key = "ComisionComercio", message = "Comision establecido.", result });
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