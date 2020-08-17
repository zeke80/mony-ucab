using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestClass.Paypal
{
    //[TestClass]
    public class Paypal
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void crear_pago()
        {
            Random ran = new Random();
            int ranNum = ran.Next(1000000000, 999999999);
            dynamic infoPago = new
            {
                reg = true,
                idOperacion = 1,
                payment = new
                {
                    intent = "sale",
                    payer = new
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<dynamic>()
                    {
                        new
                        {
                            amount = new
                            {
                                total = "30.11",
                                currency = "USD",
                                details = new
                                {
                                    subtotal = "30.00",
                                    tax = "0.07",
                                    shipping = "0.03",
                                    handling_fee = "1.00",
                                    shipping_discount = "-1.00",
                                    insurance = "0.01"
                                },
                            },
                            description = "The payment transaction description.",
                            custom = "EBAY_EMS_90048630024435",
                            invoice_number = "48787589673",
                            payment_options = new
                            {
                                allowed_payment_method = "INSTANT_FUNDING_SOURCE"
                            },
                            soft_descriptor = "ECHI5786786",
                            item_list = new
                            {
                                items = new List<dynamic>()
                                {
                                    new
                                    {
                                        name = "hat",
                                        description = "Brown hat.",
                                        quantity = "5",
                                        price = "3",
                                        tax = "0.01",
                                        sku = "1",
                                        currency = "USD"
                                    },
                                    new
                                    {
                                        name = "handbag",
                                        description = "Black handbag.",
                                        quantity = "1",
                                        price = "15",
                                        tax = "0.02",
                                        sku = "product34",
                                        currency = "USD"
                                    },
                                },
                                shipping_address = new
                                {
                                    recipient_name = "Brian Robinson",
                                    line1 = "4th Floor",
                                    line2 = "Unit #34",
                                    city = "San Jose",
                                    country_code = "US",
                                    postal_code = "95131",
                                    phone = "011862212345678",
                                    state = "CA"
                                }
                            }
                        },
                    },
                    note_to_payer = "Contact us for any questions on your order.",
                    redirect_urls = new 
                    {
                        return_url = "",
                        cancel_url = ""
                    }
                }
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.CrearPago(infoPago);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
