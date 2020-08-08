import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pago-paypal',
  templateUrl: './pago-paypal.page.html',
  styleUrls: ['./pago-paypal.page.scss'],
})
export class PagoPaypalPage implements OnInit {

  paypalForm = { 
    "reg":true, 
    "idOperacion": 0, 
    "payment":{ 
        "intent": "sale", 
        "payer": { "payment_method": "paypal" }, 
        "transactions": [ { 
                "amount": { 
                    "total": "30.11", 
                    "currency": "USD", 
                    "details": { 
                        "subtotal": "30.00", 
                        "tax": "0.00", 
                        "shipping": "0.00", 
                        "handling_fee": "0.00", 
                        "shipping_discount": "0.00", 
                        "insurance": "0.00" 
                            } 
                        }, 
                "description": "pago de reintegro", 
                "custom": "EBAY_EMS_90048630024435", 
                "invoice_number": "48787589673", 
                "payment_options": { 
                        "allowed_payment_method": "INSTANT_FUNDING_SOURCE" }, 
                        "soft_descriptor": "ECHI5786786", 
                        "item_list": { 
                            "items": [ { 
                                "name": "hat", 
                                "description": "Brown hat.", 
                                "quantity": "5", 
                                "price": "3", 
                                "tax": "0.01",  
                                "sku": "1", 
                                "currency": "USD" 
                                    }, { 
                                "name": "handbag", 
                                "description": "Black handbag.", 
                                "quantity": "1", 
                                "price": "15", 
                                "tax": "0.02", 
                                "sku": "product34", 
                                "currency": "USD" 
                                    } ], 
                            "shipping_address": { 
                                "recipient_name": "Brian Robinson", 
                                "line1": "4th Floor", 
                                "line2": "Unit #34", 
                                "city": "San Jose", 
                                "country_code": "US", 
                                "postal_code": "95131", 
                                "phone": "011862212345678", 
                                "state": "CA" 
        } } } ],
     "note_to_payer": "Contact us for any questions on your order.", 
    "redirect_urls": { "return_url": "https://example.com/return", 
    "cancel_url": "https://example.com/cancel" } } 
  
  }

  reintegroDetalle = {
    "idReintegro": null,
    "idUsuarioSolicitante": null,
    "fecha": {
        "year": null,
        "month": null,
        "day": null,
    },
    "monto": null,
    "estatus": '',
    "referencia": ''
  }
 

  constructor(private router: Router, private formModulo: FormsModule) { }

  setDetalle(){
    this.reintegroDetalle.idReintegro = localStorage.getItem('idReintegroDetalle');
    this.reintegroDetalle.idUsuarioSolicitante = localStorage.getItem('idUsuarioSolicitanteDetalle');
    this.reintegroDetalle.fecha.day = localStorage.getItem('diaDetalle');
    this.reintegroDetalle.fecha.month = localStorage.getItem('mesDetalle');
    this.reintegroDetalle.fecha.year = localStorage.getItem('anoDetalle');
    this.reintegroDetalle.monto = localStorage.getItem('montoDetalle');
    this.reintegroDetalle.estatus = localStorage.getItem('estatusDetalle');
    this.reintegroDetalle.referencia = localStorage.getItem('referenciaDetalle');
   }

  onSubmit(){
    this.paypalForm.payment.transactions= [ { 
      "amount": { 
          "total": this.reintegroDetalle.monto, 
          "currency": "USD", 
          "details": { 
              "subtotal": "30.00", 
              "tax": "0.00", 
              "shipping": "0.00", 
              "handling_fee": "0.00", 
              "shipping_discount": "0.00", 
              "insurance": "0.00" 
                  } 
              }, 
      "description": "pago de reintegro", 
      "custom": "EBAY_EMS_90048630024435", 
      "invoice_number": "48787589673", 
      "payment_options": { 
              "allowed_payment_method": "INSTANT_FUNDING_SOURCE" }, 
              "soft_descriptor": "ECHI5786786", 
              "item_list": { 
                  "items": [ { 
                      "name": "hat", 
                      "description": "Brown hat.", 
                      "quantity": "5", 
                      "price": "3", 
                      "tax": "0.01",  
                      "sku": "1", 
                      "currency": "USD" 
                          }, { 
                      "name": "handbag", 
                      "description": "Black handbag.", 
                      "quantity": "1", 
                      "price": "15", 
                      "tax": "0.02", 
                      "sku": "product34", 
                      "currency": "USD" 
                          } ], 
                  "shipping_address": { 
                      "recipient_name": "Brian Robinson", 
                      "line1": "4th Floor", 
                      "line2": "Unit #34", 
                      "city": "San Jose", 
                      "country_code": "US", 
                      "postal_code": "95131", 
                      "phone": "011862212345678", 
                      "state": "CA" 
} } } ];

  }

  ngOnInit() {
    this.setDetalle();
  }

}
