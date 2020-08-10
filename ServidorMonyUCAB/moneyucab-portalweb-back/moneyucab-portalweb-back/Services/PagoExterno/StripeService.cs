using moneyucab_portalweb_back.EntitiesForm;
using PayPal.Api;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Services.PagoExterno
    {
        public class StripeServices
        {
            public static ChargeForm CrearPago(int amount, string emailReceptor, string descripcion, Boolean reg, int idOperacion)
            {
                StripeConfiguration.ApiKey = "sk_test_8noVdkN2BH1skvu8BNgKj7JB00YSGZzcre";


                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    Source = "tok_mastercard",
                    Description = descripcion,
                    ReceiptEmail = emailReceptor
                    
                };
                var service = new ChargeService();
                var Charge = service.Create(options);
                ChargeForm chargeForm = new ChargeForm();
                chargeForm.monto = amount;
                chargeForm.descripcion = descripcion;
                chargeForm.emailReceptor = emailReceptor;
                chargeForm.id = Charge.Id;
                chargeForm.reg = reg;
                chargeForm.idOperacion = idOperacion;

                return chargeForm;

            }





        }
    }

