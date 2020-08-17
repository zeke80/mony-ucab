import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { PagoService } from '../../servicios/pago/pago.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-pago',
  templateUrl: './pago.page.html',
  styleUrls: ['./pago.page.scss'],
})
export class PagoPage implements OnInit {

  usuario: Usuario
  pagos = [];
  aux: number;

  constructor(
    public _usuarioServices: UsuarioService,
    public _pagoSercives: PagoService,
    public router: Router,
    public alert: AlertController
  ) { }

  ngOnInit() {
    this.usuario = this._usuarioServices.getUsuario();
  }

  realizarSolicitud( f: NgForm) {
    let cant: number = + f.value.monto;
    let text = f.value.user.toUpperCase();
    this._pagoSercives.solicitudPago(this.usuario.idUsuario, text, cant )
        .subscribe((data: any) => {
          this.aux = data;
          this._pagoSercives.getPagosSol(this.usuario.idUsuario)
              .subscribe((data: any) => {
                this.pagos = data;
                this._pagoSercives.guardarPagoSol(this.pagos);
                console.log(this.pagos);
                this.router.navigate(['/tabs/cuenta/pagoSinSolicitud', this.aux]);

              });
        },
        (error: HttpErrorResponse) => {
          if (error.status === 409) {
            this.AlertaError();
          }
          else {
            this.AlertaError();
          }
        });
  }

  async AlertaError() {
    const alertElement = await this.alert.create({
      header: 'Error al realizar apgo',
      message: 'El usuario no existe en el sistema',
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
