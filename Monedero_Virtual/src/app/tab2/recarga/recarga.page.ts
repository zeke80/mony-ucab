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

  usuario: Usuario
  pagos = [];
  aux: number;

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
  }

  realizarSolicitud( f: NgForm) {
    let cant: number = + f.value.monto;
    this._pagoSercives.solicitudPago(this.usuario.idUsuario, this.usuario.usuario, cant )
        .subscribe((data: any) => {
          this.aux = data;
          this._pagoSercives.getPagosSol(this.usuario.idUsuario)
              .subscribe((data: any) => {
                this.pagos = data;
                this._pagoSercives.guardarPagoSol(this.pagos);
                console.log(this.pagos);
                this.router.navigate(['/tabs/cuenta/pagoRecarga', this.aux]);

              },
              (error: HttpErrorResponse) => {
                  this.AlertServer();
      
              });
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
