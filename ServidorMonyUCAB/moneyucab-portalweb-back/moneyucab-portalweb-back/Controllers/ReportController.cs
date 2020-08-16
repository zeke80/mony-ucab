using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;

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

        [HttpGet]
        [Authorize]
        [Route("RetiroRango")]
    
        public async Task<Object> RetipoRango()
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_RetiroRando().Ejecutar());
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

        [HttpGet]
        [Authorize]
        [Route("CountOperaciones")]

        public  int CountOperaciones([FromBody]int idtipo)
        {
            int result = FabricaComandos.Fabricar_Cmd_Count_OperacionesM(idtipo).Ejecutar();
            return result;

         /*   try
            {

            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }*/
        }

        [HttpGet]
        [Authorize]
        [Route("TotalOperaciones")]

        public int TotalOperaciones()
        {
            int result = FabricaComandos.Fabricar_Cmd_Total_Operaciones().Ejecutar();
            return result;
            /*try
            {
                
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }*/
        }

        [HttpGet]
        [Authorize]
        [Route("TotalComisiones")]

        public int TotalComisiones()
        {
            int result = FabricaComandos.Fabricar_Cmd_Total_Comisiones().Ejecutar();
            return result;
          /*  try
            {
                
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }*/
        }

        [HttpGet]
        [Authorize]
        [Route("TotalCobrosPendientes")]

        public int TotalCobrosPendientes()
        {
            int result = FabricaComandos.Fabricar_Cmd_Total_CobrosPendientes().Ejecutar();
            return result;

            /*try
            {
                
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }*/
        }


    }
}
