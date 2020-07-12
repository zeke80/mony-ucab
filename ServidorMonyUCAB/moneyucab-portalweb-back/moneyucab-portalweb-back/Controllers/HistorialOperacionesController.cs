using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunes.Comun;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Comandos;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialOperacionesController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        [Route("HistorialOperacionesTarjeta")]
        //GET: /api/Dashboard/HistorialOperacionesTarjeta
        public async Task<Object> HistorialOperacionesTarjeta([FromQuery]int IdTarjeta)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Hist_OpTarjeta(IdTarjeta).Ejecutar());
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
        [Route("HistorialOperacionesCuenta")]
        //GET: /api/Dashboard/HistorialOperacionesCuenta
        public async Task<Object> HistorialOperacionesCuenta([FromQuery] int IdCuenta)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Hist_OpCuenta(IdCuenta).Ejecutar());
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
        [Route("HistorialOperacionesMonedero")]
        //GET: /api/Dashboard/HistorialOperacionesMonedero
        public async Task<Object> HistorialOperacionesMonedero([FromQuery] int IdUsuario)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Hist_OpMonedero(IdUsuario).Ejecutar());
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
        [Route("EjecutarCierre")]
        //GET: /api/Dashboard/HistorialOperacionesMonedero
        public async Task<Object> EjecutarCierre([FromQuery] int IdUsuario)
        {

            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Ejecutar_Cierre(IdUsuario).Ejecutar());
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
    }
}