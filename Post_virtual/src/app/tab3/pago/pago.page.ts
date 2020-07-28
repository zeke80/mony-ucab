import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { PagoService } from '../../servicios/pago/pago.service';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-pago',
  templateUrl: './pago.page.html',
  styleUrls: ['./pago.page.scss'],
})
export class PagoPage implements OnInit {

  usuario: Usuario

  cobro = {
    idUsuarioSolicitante: 0,
    emailPagador: '',
    monto: 0
}

  constructor(
    public _usuarioServices: UsuarioService,
    public _pagoSercives: PagoService,
    public router: Router,
    public alert: AlertController,
  ) { }

  ngOnInit() {
    
  }

  realizarPago(){
    this._pagoSercives.realizarCobro(this.cobro).subscribe(
      (data:any)=>{
        console.log(data);
        this.router.navigate(['/tabs/cuenta']);
      },
      (err:any)=>{
        console.log(err);
      }
    )
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
