import { Component, OnInit } from '@angular/core';
import { PagoService } from '../../servicios/pago/pago.service';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-cierre',
  templateUrl: './cierre.page.html',
  styleUrls: ['./cierre.page.scss'],
})
export class CierrePage implements OnInit {

  pagos = [];
  usuario: Usuario;

  constructor(
    public _usuarioService: UsuarioService,
    public _pagoServices: PagoService,
    public _operacionServices: OperacionService,
    public alert: AlertController
  ) { }

  ngOnInit() {
 /* //  this.usuario = this._usuarioService.getUsuario();
    this.pagos = this._pagoServices.getVacio();
    this._operacionServices.cierre(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.pagos = data;
        },
        (error: HttpErrorResponse) => {
            this.AlertServer();
        });*/
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
