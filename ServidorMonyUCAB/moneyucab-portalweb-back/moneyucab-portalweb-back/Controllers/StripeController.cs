using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.EntitiesForm;
using Stripe;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("CrearPago")]
        public async Task<Object> CrearPago([FromBody] ChargeForm model)
        {
            try
            {
                ChargeForm payment = await FabricaComandos.Fabricar_Cmd_Stripe_Payouts(model.monto, model.emailReceptor, model.descripcion, model.reg, model.idOperacion).Ejecutar();
                await FabricaComandos.Fabricar_Cmd_Pago_Stripe(model.reg, model.idOperacion, payment.id).Ejecutar();
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
        [Route("RecargaStripe")]
        public async Task<Object> RecargaStripe([FromBody] RecargaStripeForm model)
        {
            try
            {
                ChargeForm payment = await FabricaComandos.Fabricar_Cmd_Stripe_Payouts(model.monto, model.emailReceptor, model.descripcion, model.reg, model.idOperacion).Ejecutar();
                await FabricaComandos.Fabricar_Cmd_Recarga_Monedero_Cuenta(model.idusuarioreceptor, model.idcuenta, (model.monto)/100).Ejecutar();
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
        [Route("ReintegroStripe")]
        public async Task<Object> ReintegroStripe([FromBody] ChargeForm model)
        {
            try
            {
                ChargeForm payment = await FabricaComandos.Fabricar_Cmd_Stripe_Payouts(model.monto, model.emailReceptor, model.descripcion, model.reg, model.idOperacion).Ejecutar();
                await FabricaComandos.Fabricar_Cmd_Pago_Stripe(model.reg, model.idOperacion, payment.id).Ejecutar();
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
    }
}
