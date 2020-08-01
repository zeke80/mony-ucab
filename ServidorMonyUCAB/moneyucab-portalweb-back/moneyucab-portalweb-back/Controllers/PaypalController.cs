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
using PayPal.Api;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaypalController : ControllerBase
    {
        private string _baseUrl;

        [HttpPost]
        [Authorize]
        [Route("CrearPago")]
        public async Task<Object> CrearPago([FromBody] TransferenciaExternaPayPal Formulario) 
        {
            try
            {
                await FabricaComandos.Fabricar_Cmd_Cambio_Status(Formulario.reg, Formulario.idOperacion, Formulario.status).Ejecutar();
                Payment payment = await FabricaComandos.Fabricar_Cmd_Crear_Pago_Paypal(_baseUrl, "sale", Formulario.listaT).Ejecutar();
                return payment;
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
        [Route("PagoCancelado")]
        public async Task<Object> PagoCancelado([FromBody] TransferenciaExternaPayPal Formulario)
        {
            try
            {
                await FabricaComandos.Fabricar_Cmd_Cambio_Status(Formulario.reg, Formulario.idOperacion, Formulario.status).Ejecutar();
                return Ok();
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
        [Route("PagoExitoso")]
        public async Task<Object> PagoExitoso([FromBody] EjecuciónPagoExterno Formulario)
        {
            try
            {
                Payment pago = await FabricaComandos.Fabricar_Cmd_Ejecutar_Pago_Paypal(Formulario.idPago, Formulario.idUsuarioPagante).Ejecutar();
                await FabricaComandos.Fabricar_Cmd_Pago_Paypal(Formulario.reg, Formulario.idOperacion, pago.id).Ejecutar();
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
        }
    }
}