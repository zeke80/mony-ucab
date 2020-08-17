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
  selector: 'app-retiro',
  templateUrl: './retiro.page.html',
  styleUrls: ['./retiro.page.scss'],
})
export class RetiroPage implements OnInit {

  usuario: Usuario;

  auxT = false;
  auxC = false;
  show = true;

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
  }

  obtenerIDtajeta() {
  }

  obtenerIDcuenta() {
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

    this._pagoSercives.realizarRetiro(body)
        .subscribe((data: any) => {
          this.show = true;
          this.router.navigate(['/tabs/cuenta']);
        });

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
