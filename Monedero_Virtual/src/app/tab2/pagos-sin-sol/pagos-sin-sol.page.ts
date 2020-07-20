import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pago } from '../../models/pago.model';
import { PagoService } from '../../servicios/pago/pago.service';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { Usuario } from '../../models/usuario.model';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../../servicios/tarjeta/tarjeta.service';
import { AlertController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-pagos-sin-sol',
  templateUrl: './pagos-sin-sol.page.html',
  styleUrls: ['./pagos-sin-sol.page.scss'],
})
export class PagosSinSolPage implements OnInit {

  operacion: Pago;
  usuario: Usuario;
  user: string;
  saldo: number;
  monto: number;
  metodoPagoC = [];
  metodoPagoT = [];
  auxT = false;
  auxC = false;
  auxM = false;
  tarjeta: any;
  cuenta: any;

  constructor(
    public _activatedRoute: ActivatedRoute,
    public _pagoServices: PagoService,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService,
    public _tarjetaServices: TarjetaService,
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
    this._usuarioServices.getSaldo(this.usuario.idUsuario)
        .subscribe((data:any) => {
          this.saldo = data;
        });
  }

  realizarSolicitud(f: NgForm) {
    this.auxM = true;
    this.user = f.value.user;
    this.monto = f.value.monto;

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

    this._usuarioServices.getUserInfo(this.user)
        .subscribe((data: any) => {
          var body = {
            idUsuarioReceptor: data.result.idUsuario,
            idMedioPaga: id,
            monto: this.monto,
            idOperacion: 2
          };

          this._pagoServices.realizarPagoTarjeta(body)
              .subscribe((data:any) => {
                this.router.navigate(['/tabs/cuenta']);
              });

        });

  }

  pagarCuenta() {
    let id: number = + this.cuenta;

    this._usuarioServices.getUserInfo(this.user)
        .subscribe((data: any) => {
          var body = {
            idUsuarioReceptor: data.result.idUsuario,
            idMedioPaga: id,
            monto: this.monto,
            idOperacion: 2
          };

          this._pagoServices.realizarPagoCuenta(body)
              .subscribe((data:any) => {
                this.router.navigate(['/tabs/cuenta']);
              });

        });
  }

  pagarMonedero() {
    if (this.monto > this.saldo) {
      this.AlertSaldo();
      return;
    }
    this._usuarioServices.getUserInfo(this.user)
    .subscribe((data: any) => {
      var body = {
        idUsuarioReceptor: data.result.idUsuario,
        idMedioPaga: this.usuario.idUsuario,
        monto: this.monto,
        idOperacion: 2
      };

      this._pagoServices.realizarPagoMonedero(body)
          .subscribe((data:any) => {
            this.router.navigate(['/tabs/cuenta']);
          });

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

}
