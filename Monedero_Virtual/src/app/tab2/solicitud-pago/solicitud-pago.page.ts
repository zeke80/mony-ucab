import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pago } from '../../models/pago.model';
import { PagoService } from '../../servicios/pago/pago.service';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { Usuario } from '../../models/usuario.model';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../../servicios/tarjeta/tarjeta.service';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-solicitud-pago',
  templateUrl: './solicitud-pago.page.html',
  styleUrls: ['./solicitud-pago.page.scss'],
})
export class SolicitudPagoPage implements OnInit {

  operacion: Pago;
  usuario: Usuario;
  aux: number;

  auxT = false;
  auxC = false;

  metodoPagoC = [];
  metodoPagoT = [];

  tarjeta: any;
  cuenta: any;

  saldo: number;

  constructor(
    public _activatedRoute: ActivatedRoute,
    public _pagoServices: PagoService,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService,
    public _tarjetaServices: TarjetaService,
    public router: Router,
    public alert: AlertController,
  ) { }

  ngOnInit() {
    this._activatedRoute.paramMap.subscribe(paramMap => {
      const recipeID = paramMap.get('pagoID');
      let id: number = +recipeID;
      this.operacion = this._pagoServices.getpago(id);
      console.log(this.operacion)
    });

    this.usuario = this._usuarioServices.getUsuario();
    this._cuentaServices.obtenerCuenta(this.usuario.idUsuario)
        .subscribe((data: any) =>  {
          this.metodoPagoC = data;
        });
    this._tarjetaServices.obtenerTarjetas(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.metodoPagoT = data;
        });
    this._usuarioServices.getSaldo(this.usuario.idUsuario)
        .subscribe((data:any) => {
          this.saldo = data;
        });

    // this._usuarioServices.inforUsurio(this.operacion.idUsuarioReceptor)
    //     .subscribe((data: any) => {
    //       this.user = data.usuario;
    //     });
    // this.usuario = this._usuarioServices.getUsuario();
    // this._cuentaServices.getCuentas(this.usuario.idUsuario)
    //     .subscribe((data: any) => {
    //       console.log(data);
    //       this.metodoPagoC = data;
    //     });
    // this._tarjetaServices.getTarjetas(this.usuario.idUsuario)
    //     .subscribe((data: any) => {
    //       this.metodoPagoT = data;
    //     });
    // this.saldo = this._pagoServices.getSaldo();
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

  pagarTarjeta() {
    let id: number = + this.tarjeta;
    let cant: number = + this.operacion.monto;
    var body = {
      idUsuarioReceptor: this.operacion.idUsuarioSolicitante,
      idMedioPaga: id,
      monto: cant,
      idOperacion: this.operacion.idPago
    };

    console.log(body);

    this._pagoServices.realizarPagoTarjeta(body)
        .subscribe((data:any) => {
          console.log(data);
          this.router.navigate(['/tabs/cuenta']);
        });

  }

  pagarCuenta() {
    let id: number = + this.cuenta;
    let cant: number = + this.operacion.monto;
    var body = {
      idUsuarioReceptor: this.operacion.idUsuarioSolicitante,
      idMedioPaga: id,
      monto: cant,
      idOperacion: this.operacion.idPago
    };

    console.log(body);

    this._pagoServices.realizarPagoCuenta(body)
        .subscribe((data:any) => {
          this.router.navigate(['/tabs/cuenta']);
        });
  }

  pagarMonedero() {
    let cant: number = + this.operacion.monto;
    if (cant > this.saldo) {
      this.AlertSaldo();
      return;
    }

    var body = {
      idUsuarioReceptor: this.operacion.idUsuarioSolicitante,
      idMedioPaga: this.usuario.idUsuario,
      monto: cant,
      idOperacion: this.operacion.idPago
    };

    this._pagoServices.realizarPagoMonedero(body)
        .subscribe((data:any) => {
          this.router.navigate(['/tabs/cuenta']);
        });

  }

  async AlertSaldo() {
    const alertElement = await this.alert.create({
      header: 'Saldo insuficiente',
      message: '',
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

  async AlertaError() {
    const alertElement = await this.alert.create({
      header: 'Error en pago',
      message: 'El saldo no es suficiente',
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
