import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Pago } from '../../models/pago.model';
import { FormBuilder, Validators } from '@angular/forms';
import { Cobro } from 'src/app/models/cobro.model';
import { FormsModule } from '@angular/forms';
import {  FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PagoService {


  public cobro: Cobro[] = [
    {
      idUsuarioSolicitante: 0,
    emailPagador : '',
    monto: 0

    }
  ];

  formModel = this.form.group({
    idUsuarioSolicitante : [0, Validators.required],
    emailPagador : ['', [Validators.required, Validators.email]],
    monto : [0, Validators.required]
  });

  basic = 'Bearer ' +localStorage.getItem('token');

  public pagos: Pago[] = [
    {
      idpago: 1,
      idusuariosolicitante: 1,
      idusuarioreceptor: 1,
      fechasolicitud: '01/01/2020',
      monto: 0,
      estatus: '1'
    }
  ];


  solicitante = '1';

  constructor(
    public http: HttpClient,private form: FormBuilder
  ) { }

  getVacio() {
    return [...this.pagos];
  }

  guardarPago(pagos: Pago[]) {
    this.pagos = pagos;

  }

  getPagos(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/pagosSolicitadosSolicitante';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }

  getpago(operacionID: number){
    return {
      ...this.pagos.find(operacion => {
        return operacion.idpago === operacionID;
      })
    };
  }

  solicitudPago(id: number, user: string, mont: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/solicitarPago';

    let data = {
      "idUsuarioSolicitante" : id,
      "userReceptor" : user,
      "monto" : mont
    };

    return this.http.post(url, data);
  }

  cobrosActivos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', this.solicitante )
    return this.http.get('http://localhost:80/api/dashboard/cobrosactivos', {params: param, headers: header})
  }

  cobrosCancelados(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', '1')
    return this.http.get('http://localhost:80/api/dashboard/CobrosCancelados', {params: param, headers: header})
  }

  cobrosExitosos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', '1')
    return this.http.get('http://localhost:80/api/dashboard/CobrosExitosos', {params: param, headers: header})
  }

  realizarCobro(cobro: Cobro){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    var body = {
      idUsuarioSolicitante: parseInt(localStorage.getItem('idUsuario')),
      emailPagador: cobro.emailPagador,
      monto: cobro.monto
    }
    console.log(body);
    return this.http.post('http://localhost:80/api/Transfer/realizarcobro',body, {headers: header});
  }

  cancelarCobro(IdCobro){
    console.log(IdCobro);

    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});

    let param = new HttpParams().set('IdCobro', IdCobro);


    const options = {
      headers: header,
      params: param
    };

    console.log(options);

    return this.http.post('http://localhost:80/api/Transfer/CancelarCobro',null, options)
  }

  crearPagoPaypal(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    //console.log(paypalForm);

    var body  = { 
      "reg":false, 
      "idOperacion": 1, 
      "payment":{ 
          "intent": "sale", 
          "payer": { "payment_method": "paypal" }, 
          "transactions": [ { 
                  "amount": { 
                      "total": "", 
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
                  "description": "The payment transaction description.", 
                  "custom": "EBAY_EMS_90048630024435", 
                  "invoice_number": "48787589673", 
                  "payment_options": { 
                          "allowed_payment_method": "INSTANT_FUNDING_SOURCE" }, 
                          "soft_descriptor": "ECHI5786786", 
                          "item_list": { 
                              "items": [ { 
                                  "name": "hat", 
                                  "description": "Brown hat.", 
                                  "quantity": "1", 
                                  "price": "0", 
                                  "tax": "0.00",  
                                  "sku": "0", 
                                  "currency": "USD" 
                                      }, { 
                                  "name": "handbag", 
                                  "description": "Black handbag.", 
                                  "quantity": "1", 
                                  "price": "0", 
                                  "tax": "0.00", 
                                  "sku": "product34", 
                                  "currency": "USD" 
                                      } ], 
                              "shipping_address": { 
                                  "recipient_name": "Brian Robinson", 
                                  "line1": "asd", 
                                  "line2": "asd", 
                                  "city": "asd", 
                                  "country_code": "US", 
                                  "postal_code": "1234", 
                                  "phone": "02129450643", 
                                  "state": "guarico" 
          } } } ],
       "note_to_payer": "Contact us for any questions on your order.", 
      "redirect_urls": { "return_url": "http://localhost:8100/tabs/operaciones/reintegro-detalle/pago-paypal/payment-message", 
      "cancel_url": "http://localhost:8100/tabs/operaciones/reintegro-detalle/pago-paypal/payment-message" } } }
      //console.log(body);
      var num2 = parseInt(localStorage.getItem('idReintegroDetalle'));
      body.idOperacion = num2;
      body.payment.transactions[0].amount.total = localStorage.getItem('montoDetalle');
      body.payment.transactions[0].amount.details.subtotal = localStorage.getItem('montoDetalle');
      body.payment.transactions[0].item_list.items[0].price = localStorage.getItem('montoDetalle');
      body.payment.transactions[0].item_list.shipping_address.city = localStorage.getItem('ciudadPaypal');
      body.payment.transactions[0].item_list.shipping_address.state = localStorage.getItem('estadoPaypal');
      body.payment.transactions[0].item_list.shipping_address.line1 = localStorage.getItem('direccion1');
      body.payment.transactions[0].item_list.shipping_address.line2 = localStorage.getItem('direccion2');
      body.payment.transactions[0].item_list.shipping_address.postal_code = localStorage.getItem('codPost');
      body.payment.transactions[0].item_list.shipping_address.phone = localStorage.getItem('telfPaypal');

      //console.log(localStorage.getItem('ciudadPaypal'));

    return this.http.post('http://localhost:80/api/Paypal/CrearPago',body, {headers: header});
  }

}
