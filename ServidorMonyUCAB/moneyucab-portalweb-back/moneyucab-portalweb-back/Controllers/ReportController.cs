using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.EntitiesForm;
using NpgsqlTypes;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReportController : Controller
    {

        [HttpGet]
        [Authorize]
        [Route("ComisionesPorEmpresa")]
        public async Task<Object> ComisionPorEmpresa()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Comisiones_PorEmpresa().Ejecutar());
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
        [Route("CobrosPendientes")]
        public async Task<Object> CobrosPendientes()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Cobros_Pendientes().Ejecutar());
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

        /*[HttpPost]
        [Authorize]
        [Route("RetiroRango")]

        public async Task<Object> RetiroRango([FromBody] RangoFechas rangoFechas)
        {

            try
            {
                object lista = await FabricaComandos.Fabricar_Cmd_RetiroRango(rangoFechas.fecha1, rangoFechas.fecha2).Ejecutar();
                return lista;
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
        }*/

        [HttpGet]
        [Authorize]
        [Route("OperacionesFallidas")]
        
        public async Task<Object> OperacionesFallidas()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Operaciones_Fallidas().Ejecutar());
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

        [HttpPost]
        [Authorize]
        [Route("CountOperaciones")]

        public object CountOperaciones([FromBody]int idtipo)
        {


               try
               {
                int result = FabricaComandos.Fabricar_Cmd_Count_OperacionesM(idtipo).Ejecutar();
                   return result;
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
        [Route("TotalOperaciones")]

        public object TotalOperaciones()
        {
            
            try
            {
                int result = FabricaComandos.Fabricar_Cmd_Total_Operaciones().Ejecutar();
                return result;

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
        [Route("TotalComisiones")]

        public object TotalComisiones()
        {

              try
              {
                  int result = FabricaComandos.Fabricar_Cmd_Total_Comisiones().Ejecutar();
              return result;
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
        [Route("TotalCobrosPendientes")]

        public object TotalCobrosPendientes()
        {
            try
            {
             int result = FabricaComandos.Fabricar_Cmd_Total_CobrosPendientes().Ejecutar();
            return result;   
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

       /*[HttpPost]
        [Authorize]
        [Route("RetiroDia")]

        public async Task<Object> RetiroDia([FromBody] string fecha1)
        {

            try
            {
                object lista = await FabricaComandos.Fabricar_Cmd_Retiro_Dia(fecha1).Ejecutar();
                return lista;
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

        [HttpPost]
        [Authorize]
        [Route("RetiroMes")]

        public async Task<Object> RetiroMes([FromBody] string mes)
        {

            try
            {
                object lista = await FabricaComandos.Fabricar_Cmd_Retiro_Mes(mes).Ejecutar();
                return lista;
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

        [HttpPost]
        [Authorize]
        [Route("RetiroAnual")]

        public async Task<Object> RetiroAnual([FromBody] string ano)
        {

            try
            {

                object lista = await FabricaComandos.Fabricar_Cmd_Retiro_Anual(ano).Ejecutar();
                return lista;
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
        }*/


    }
}
