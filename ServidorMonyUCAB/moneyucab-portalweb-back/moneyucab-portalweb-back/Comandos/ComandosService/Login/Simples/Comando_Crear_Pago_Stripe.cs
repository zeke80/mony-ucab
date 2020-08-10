using Comandos;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Services.PagoExterno;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Crear_Pago_Stripe : Comando<Payout>
    {
        private int _amount;
        private string _descripcion;
        private string _emailReceptor;
        private Boolean _reg;
        private int _id;

        public Comando_Crear_Pago_Stripe(int amount, string emailReceptor, string descripcion, Boolean reg, int idOperacion)
        {
            this._amount = amount;
            this._descripcion = descripcion;
            this._emailReceptor = emailReceptor;
            this._reg = reg;
            this._id = idOperacion;

        }

        async public Task<ChargeForm> Ejecutar()
        {

            ChargeForm payout = StripeServices.CrearPago(this._amount, this._emailReceptor, this._descripcion, this._reg, this._id);
            return payout;
        }
    }
}
