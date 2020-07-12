using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Comandos;
using Excepciones;
using Microsoft.AspNetCore.Authorization;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("RealizarCobro")]
        public async Task<Object> RealizarCobro([FromBody]Cobro Cobro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Realizar_Cobro(Cobro.idUsuarioSolicitante, Cobro.emailPagador, Cobro.monto).Ejecutar();
                return Ok(new { key = "RealizarCobro", message = "Cobro realizado", result });

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
        [Route("SolicitarReintegro")]
        public async Task<Object> SolicitarReintegro([FromBody] Reintegro Reintegro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Solicitar_Reintegro(Reintegro.idUsuarioSolicitante, Reintegro.emailPagador, Reintegro.referencia).Ejecutar();
                return Ok(new { key = "SolicitudReintegro", message = "Reintegro solicitado", result });

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
        [Route("CancelarCobro")]
        public async Task<Object> CancelarCobro([FromQuery] int IdCobro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Cancelar_Cobro(IdCobro).Ejecutar();
                return Ok(new { key = "CancelarCobro", message = "Cobro cancelado", result });

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
        [Route("CancelarReintegro")]
        public async Task<Object> CancelarReintegro([FromQuery] int IdReintegro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Cancelar_Reintegro(IdReintegro).Ejecutar();
                return Ok(new { key = "CancelarReintegro", message = "Reintegro cancelado", result });

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
        [Route("RealizarPagoCuenta")]
        public async Task<Object> Realizar_Pago_Cuenta([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Pago_Cuenta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto, Formulario.idOperacion).Ejecutar();
                return Ok(new { key = "RealizarPagoCuenta", message = "Pago realizado", result });

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
        [Route("RealizarPagoTarjeta")]
        public async Task<Object> Realizar_Pago_Tarjeta([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Pago_Tarjeta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto, Formulario.idOperacion).Ejecutar();
                return Ok(new { key = "RealizarPagoTarjeta", message = "Pago realizado", result });

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
        [Route("RealizarPagoMonedero")]
        public async Task<Object> Realizar_Pago_Monedero([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Pago_Monedero(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto, Formulario.idOperacion).Ejecutar();
                return Ok(new { key = "RealizarPagoMonedero", message = "Pago realizado", result });

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
        [Route("RealizarReintegroCuenta")]
        public async Task<Object> Realizar_Reintegro_Cuenta([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Reintegro_Cuenta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto, Formulario.idOperacion).Ejecutar();
                return Ok(new { key = "RealizarReintegroCuenta", message = "Reintegro realizado", result });

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
        [Route("RealizarReintegroTarjeta")]
        public async Task<Object> Realizar_Reintegro_Tarjeta([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Reintegro_Tarjeta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto, Formulario.idOperacion).Ejecutar();
                return Ok(new { key = "RealizarReintegroTarjeta", message = "Reintegro realizado", result });

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
        [Route("RealizarReintegroMonedero")]
        public async Task<Object> Realizar_Reintegro_Monedero([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Reintegro_Monedero(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto, Formulario.idOperacion).Ejecutar();
                return Ok(new { key = "RealizarReintegroMonedero", message = "Reintegro realizado", result });

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
        [Route("EstablecerParametro")]
        public async Task<Object> Establecer_Parametro([FromBody] EstParametro Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Establecer_Parametro(Formulario.idUsuario, Formulario.idParametro, Formulario.validacion, Formulario.estatus).Ejecutar();
                return Ok(new { key = "EstablecerParametro", message = "Parametro Establecido", result });

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