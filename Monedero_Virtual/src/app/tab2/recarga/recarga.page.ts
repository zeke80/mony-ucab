import { Component, OnInit } from '@angular/core';
import { PagoService } from '../../servicios/pago/pago.service';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { Usuario } from '../../models/usuario.model';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../../servicios/tarjeta/tarjeta.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-recarga',
  templateUrl: './recarga.page.html',
  styleUrls: ['./recarga.page.scss'],
})
export class RecargaPage implements OnInit {

  usuario: Usuario;

  auxT = false;
  auxC = false;
  show = true;
  showP = true;

  metodoPagoC = [];
  metodoPagoT = [];

  tarjeta: any;
  cuenta: any;

  constructor(
    public _pagoServices: PagoService,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService,
    public _tarjetaServices: TarjetaService,
    public _pagoSercives: PagoService,
    public router: Router,
    public alert: AlertController
  ) { }

  ngOnInit() {
    this.usuario = this._usuarioServices.getUsuario();
    this._cuentaServices.obtenerCuenta(this.usuario.idUsuario)
        .subscribe((data: any) =>  {
          this.metodoPagoC = data;
        });
    this._tarjetaServices.obtenerTarjetas(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.metodoPagoT = data;
        });
  }

  boolTarjeta() {
    this.auxT = true;
    this.auxC = false;
  }

  boolCuenta() {
    this.auxC = true;
    this.auxT = false;
  }

  obtenerIDtajeta() {
  }

  obtenerIDcuenta() {
  }

  pagarTarjeta(montoIn: number) {
    this.show = false;
    let id: number = + this.tarjeta;
    let cant: number = + montoIn;
    var body = {
      idUsuarioReceptor: this.usuario.idUsuario,
      idMedioPaga: id,
      monto: cant,
      idOperacion: 2
    };

    console.log(body);

    this._pagoSercives.recargaTarjeta(body)
        .subscribe((data: any) => {
          this.show = true;
          this.router.navigate(['/tabs/cuenta']);
        });

  }

  pagarCuenta(montoIn: number) {
    this.show = false;
    let id: number = + this.cuenta;
    let cant: number = + montoIn;
    var body = {
      idUsuarioReceptor: this.usuario.idUsuario,
      idMedioPaga: id,
      monto: cant,
      idOperacion: 2
    };

    console.log(body);



    this._pagoSercives.recargaCuenta(body)
        .subscribe((data: any) => {
          this.show = true;
          this.router.navigate(['/tabs/cuenta']);
        });

  }

  pagarPaypal(montoIn: number) {

    this.showP = false;

    let x = this.getRandom() * 10000;

    var bodyl = {
      reg: true,
      idOperacion: 0,
      payment: {
      intent: "sale",
      payer: {
        payment_method: "paypal"
      },
      transactions: [
        {
          amount: {
            total: montoIn.toString(),
            currency: "USD",
            details: {
              subtotal: montoIn.toString(),
              tax: "0",
              shipping: "0",
              handling_fee: "0",
              shipping_discount: "0",
              insurance: "0"
            }
          },
          description: "The payment transaction description.",
          custom: "EBAY_EMS_90048630024435",
          invoice_number: "55984746848723478" + Math.round(x),
          payment_options: {
            allowed_payment_method: "INSTANT_FUNDING_SOURCE"
          },
          soft_descriptor: "ECHI5786786",
          item_list: {
            items: [
              {
                name: "transacción",
                description: "",
                quantity: "1",
                price: montoIn,
                tax: "0",
                sku: "0",
                currency: "USD"
              }
            ],
            shipping_address: {
              recipient_name: "Brian Robinson",
              line1: "4th Floor",
              line2: "Unit #34",
              city: "San Jose",
              country_code: "US",
              postal_code: "95131",
              phone: "011862212345678",
              state: "CA"
            }
          }
        }
      ],
      note_to_payer: "Contact us for any questions on your order.",
      redirect_urls: {
        return_url: "http://localhost:8100/tabs/cuenta",
        cancel_url: "http://localhost:8100/tabs/cuenta"
      }
    }
    };

    console.log(bodyl);

    this._pagoServices.recargaPaypal(bodyl)
        .subscribe((data: any) => {

          localStorage.setItem('idPaga', data.id.toString());
          localStorage.setItem('recarga', 'true');
          localStorage.setItem('monto', montoIn.toString());
          console.log(data.links[1].href);

          window.location.href = data.links[1].href;
          this.showP = true;

        });


  }

  getRandom() {
    return Math.random();
  }

  async AlertServer() {
    const alertElement = await this.alert.create({
      header: 'Error inesperado',
      message: 'intentelo mas tarde',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
          }
        },

      ]
    });

    await alertElement.present();

  }

}
