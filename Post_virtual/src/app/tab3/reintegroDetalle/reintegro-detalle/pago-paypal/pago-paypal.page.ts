import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AlertController } from '@ionic/angular';
import { PagoService } from 'src/app/servicios/pago/pago.service';
import { InAppBrowser } from '@ionic-native/in-app-browser/ngx';
import { ReintegroService } from 'src/app/servicios/reintegro/reintegro.service';

@Component({
  selector: 'app-pago-paypal',
  templateUrl: './pago-paypal.page.html',
  styleUrls: ['./pago-paypal.page.scss'],
})
export class PagoPaypalPage implements OnInit {
  
  accountId = '';
  paypalForm = { 
    "reg":false, 
    "idOperacion": 0, 
    "payment":{ 
        "intent": "sale", 
        "payer": { "payment_method": "paypal" }, 
        "transactions": [ { 
                "amount": { 
                    "total": "", 
                    "currency": "USD", 
                    "details": { 
                        "subtotal": "0.00", 
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
                                "recipient_name": "john doe", 
                                "line1": "", 
                                "line2": "", 
                                "city": "", 
                                "country_code": "US", 
                                "postal_code": "", 
                                "phone": "", 
                                "state": "" 
        } } } ],
     "note_to_payer": "Contact us for any questions on your order.", 
    "redirect_urls": { "return_url": "http://localhost:8100/tabs/operaciones/reintegro-detalle/pago-paypal/confirmar-paypal", 
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

 costo = 0;

 url: string;

 webPageUrl='';

  constructor(
        private router: Router, 
        private formModulo: FormsModule,
        private alert: AlertController,
        private pagoService:PagoService,
        private inAppBrowser:InAppBrowser,
        private reintegroService:ReintegroService
        ) { }

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

  async  onSubmit(){
    
    const alert = await this.alert.create({
      header: 'Paypal',
      message: '¿Desea pagar con paypal?    Se le redirigira a la pagina oficial para observar los detalles de su pago.',
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel',
          cssClass: 'secondary',
        },
        {
          text: 'Aceptar',
          handler: () => {
            localStorage.setItem('accountId',this.accountId);
            localStorage.setItem('ciudadPaypal',this.paypalForm.payment.transactions[0].item_list.shipping_address.city);
            localStorage.setItem('estadoPaypal',this.paypalForm.payment.transactions[0].item_list.shipping_address.state);
            localStorage.setItem('direccion1',this.paypalForm.payment.transactions[0].item_list.shipping_address.line1);
            localStorage.setItem('direccion2',this.paypalForm.payment.transactions[0].item_list.shipping_address.line2);
            localStorage.setItem('codPost',this.paypalForm.payment.transactions[0].item_list.shipping_address.postal_code);
            localStorage.setItem('telfPaypal',this.paypalForm.payment.transactions[0].item_list.shipping_address.phone);
            this.pagoService.crearPagoPaypal()
            .subscribe(
              (data: any) =>
              {
               console.log(data);
               localStorage.setItem('approvalUrl', data.links[1].href);
               localStorage.setItem('payId', data.id);
                this.detallePaypal(data); 
              },
              err =>{
                console.log(err);
                
              }
            );         
          }
        }
      ]
    });
    

    await alert.present();
  }

  
  async openWebPage(url){
    this.webPageUrl = url;
    const browser = this.inAppBrowser.create(this.webPageUrl, '_system');
    
  }

  async detallePaypal(data){
    await this.openWebPage(data.links[1].href);//pasar al localstorage los valores de data
    console.log(this.webPageUrl);
    await this.router.navigate(['tabs/operaciones/reintegro-detalle/pago-paypal/confirmacion-paypal']);//placeholder confirmacion-paypal
  }

  ngOnInit() {
    this.setDetalle();
    var num = new Number(this.reintegroDetalle.monto);
    var num2 = parseInt(this.reintegroDetalle.idReintegro);
    this.paypalForm.idOperacion = num2; 
    this.paypalForm.payment.transactions[0].amount.total = num.toString();
    this.costo = this.reintegroDetalle.monto;
    //this.paypalForm.payment.transactions[0].item_list.shipping_address.
  }

}
