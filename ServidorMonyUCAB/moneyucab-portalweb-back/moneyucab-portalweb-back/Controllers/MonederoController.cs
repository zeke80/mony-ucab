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
using PayPal.Api;

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

        [HttpPost]
        [Authorize]
        [Route("RecargaPaypal")]
        public async Task<Object> Recarga_Monedero_Paypal([FromBody] TransferenciaExternaPayPal Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                await FabricaComandos.Fabricar_Cmd_Cambio_Status(Formulario.reg, Formulario.idOperacion, 1).Ejecutar();
                Payment payment = await FabricaComandos.Fabricar_Cmd_Crear_Pago_Paypal("", "sale", Formulario.payment).Ejecutar();
                var result = await FabricaComandos.Fabricar_Cmd_Recarga_Monedero_Cuenta(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto).Ejecutar();
                return Ok(payment);

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
        [Route("RecargaExitosaPaypal")]
        public async Task<Object> Recarga_Exitosa_Paypal([FromBody] EjecuciónPagoExternoRecarga Formulario)
        {
            try
            {
                Payment pago = await FabricaComandos.Fabricar_Cmd_Ejecutar_Pago_Paypal(Formulario.idPago, Formulario.idUsuarioPagante).Ejecutar();
                var result = await FabricaComandos.Fabricar_Cmd_Recarga_Monedero_Cuenta(Formulario.idUsuario, Formulario.idCuenta, Formulario.monto).Ejecutar();
                return pago;
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
            finally
            {
                try
                {
                    await FabricaComandos.Fabricar_Cmd_Cambio_Status(Formulario.reg, Formulario.idOperacion, 0).Ejecutar();
                }
                catch (Exception ex)
                {
                }
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Retiro")]
        public async Task<Object> Retiro([FromBody] Transferencia Formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Retiro(Formulario.idUsuarioReceptor, Formulario.idMedioPaga, Formulario.monto).Ejecutar();
                return Ok(new { key = "RealizarRetiro", message = "Retiro realizado", result });

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