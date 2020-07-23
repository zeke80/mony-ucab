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
    public class DashboardController : ControllerBase
    {
        private UserManager<Usuario> _userManager;

        public DashboardController(UserManager<Usuario> UserManager)
        {
            _userManager = UserManager;
        }

        //Operaciones de consulta---------------------------------------------------------------

        [HttpGet]
        [Authorize]
        [Route("EstadosCiviles")]
        //GET: /api/Dashboard/EstadosCiviles
        public async Task<Object> EstadosCiviles()
        {

            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Estados_Civiles().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("TiposTarjetas")]
        //GET: /api/Dashboard/TiposTarjetas
        public async Task<Object> TiposTarjeta()
        {

            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Tipos_Tarjetas().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Bancos")]
        //GET: /api/Dashboard/Bancos
        public async Task<Object> Bancos()
        {

            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Bancos().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }


        [HttpGet]
        [Authorize]
        [Route("TiposCuentas")]
        //GET: /api/Dashboard/TiposCuentas
        public async Task<Object> TiposCuentas()
        {

            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Tipos_Cuentas().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("TiposParametros")]
        //GET: /api/Dashboard/TiposParametros
        public async Task<Object> TiposParametros()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Tipos_Parametros().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("Frecuencias")]
        //GET: /api/Dashboard/Frecuencias
        public async Task<Object> Frecuencias()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Frecuencias().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("Parametros")]
        //GET: /api/Dashboard/Parametros
        public async Task<Object> Parametros()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Parametros().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("TiposOperaciones")]
        //GET: /api/Dashboard/TiposOperaciones
        public async Task<Object> TiposOperaciones()
        {

            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Tipos_Operaciones().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("TiposIdentificaciones")]
        //GET: /api/Dashboard/TiposIdentificaciones
        public async Task<Object> TiposIdentificaciones()
        {

            try
            {
                
                return Ok(await FabricaComandos.Fabricar_Cmd_Tipos_Identificaciones().Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("Tarjetas")]
        //GET: /api/Dashboard/Tarjetas
        public async Task<Object> Tarjetas([FromQuery]int IdUsuario)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Tarjetas(IdUsuario).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Cuentas")]
        //GET: /api/Dashboard/Cuentas
        public async Task<Object> Cuentas([FromQuery]int IdUsuario)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Cuentas(IdUsuario).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ReintegrosActivos")]
        //GET: /api/Dashboard/ReintegrosActivos
        public async Task<Object> ReintegrosActivos([FromQuery] ConsultaIdSol Form)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Reintegros_Activos(Form.idUsuario, Form.solicitante).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ReintegrosCancelados")]
        //GET: /api/Dashboard/ReintegrosCancelados
        public async Task<Object> ReintegrosCancelados([FromQuery]ConsultaIdSol Form)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Reintegros_Cancelados(Form.idUsuario, Form.solicitante).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ReintegrosExitosos")]
        //GET: /api/Dashboard/ReintegrosExitosos
        public async Task<Object> ReintegrosExitosos([FromQuery]ConsultaIdSol Form)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Reintegros_Exitosos(Form.idUsuario, Form.solicitante).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("CobrosActivos")]
        //GET: /api/Dashboard/CobrosActivos
        public async Task<Object> CobrosActivos([FromQuery] ConsultaIdSol Form)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Cobros_Activos(Form.idUsuario, Form.solicitante).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("CobrosCancelados")]
        //GET: /api/Dashboard/CobrosCancelados
        public async Task<Object> CobrosCancelados([FromQuery] ConsultaIdSol Form)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Cobros_Cancelados(Form.idUsuario, Form.solicitante).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("CobrosExitosos")]
        //GET: /api/Dashboard/CobrosExitosos
        public async Task<Object> CobrosExitosos([FromQuery] ConsultaIdSol Form)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Cobros_Exitosos(Form.idUsuario, Form.solicitante).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ParametrosUsuario")]
        //GET: /api/Dashboard/ParametrosUsuario
        public async Task<Object> ParametrosUsuario([FromQuery]int IdUsuario)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Parametros_Usuario(IdUsuario).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("InformacionPersona")]
        //GET: /api/Dashboard/InformacionPersona
        public async Task<Object> InformacionPersona([FromQuery]string Usuario)
        {

            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Informacion_Persona(Usuario).Ejecutar();
                return Ok(new { result, result.tipoIdentificacion, result.persona, result.persona.estadoCivil, result.comercio });
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpGet]
        [Route("ConsultaUsuariosF")]
        //Post: /api/Authentication/Register
        public async Task<Object> ConsultarUsuariosF([FromQuery] int idUsuario)
        {
            try
            {
                return await FabricaComandos.Fabricar_Cmd_Consultar_Usuarios_Familiares(idUsuario).Ejecutar();
            }
            catch (MoneyUcabException ex)
            {
                //Debe controlarse un error dentro de la plataforma
                //Se realiza bad request respondiendo con el objeto obtenido
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

    }
}