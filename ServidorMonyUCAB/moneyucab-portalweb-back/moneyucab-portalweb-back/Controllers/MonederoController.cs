using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;
using Excepciones;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")] // api/saldo
    [ApiController]
    public class MonederoController : ControllerBase
    {
        [HttpGet] // api/Saldo/consultar
        [Authorize]
        [Route("Consultar")]
        public async Task<Object> Consultar([FromQuery]int IdUsuario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Verificar_Saldo(IdUsuario).Ejecutar());
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
        [Authorize]
        [Route("RecargaMonederoTarjeta")]
        public async Task<Object> Recarga_Monedero_Tarjeta([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Recarga_Monedero_Tarjeta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto).Ejecutar();
                return Ok(new { key = "RealizarRecargaMonedero", message = "Recarga realizada", result });

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
        [Authorize]
        [Route("RecargaMonederoCuenta")]
        public async Task<Object> Recarga_Monedero_Cuenta([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Recarga_Monedero_Cuenta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto).Ejecutar();
                return Ok(new { key = "RealizarRecargaMonedero", message = "Recarga realizada", result });

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