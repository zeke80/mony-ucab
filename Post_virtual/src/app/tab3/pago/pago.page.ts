import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { PagoService } from '../../servicios/pago/pago.service';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MenuController } from "@ionic/angular";
import { ToastController, LoadingController } from '@ionic/angular';

@Component({
  selector: 'app-pago',
  templateUrl: './pago.page.html',
  styleUrls: ['./pago.page.scss'],
})
export class PagoPage implements OnInit {

  usuario: Usuario

  cobro = {
    "idUsuarioSolicitante": 0,
    "emailPagador": '',
    "monto": 0,
}


constructor(private router: Router, private formModulo: FormsModule, 
  private menuController: MenuController,
  private loadingController: LoadingController,
  private toastController: ToastController,
  private cobroService: PagoService
  ) { }

  ngOnInit() {
    
  }

  async onSubmit(){
    await this.presentLoading();
    this.cobroService.realizarCobro(this.cobro).subscribe(
      (res:any) => {
        this.loadingController.dismiss();

        this.successToast('success', 'Cobro procesado satisfactioamente')
        this.router.navigate(['/tabs/cuenta']);
      },
      err => {
        this.loadingController.dismiss();
        console.log(err);
        this.presentToast('danger', err.error.error);
      }
    );
  }

  async presentToast(color : string, mensaje : string) {
    const toast = await this.toastController.create({
      message: mensaje,
      color : color,
      buttons: [ 
        {
          icon: 'close',
          role: 'cancel'
        }
      ]
    });
    toast.present();
  }
  
  async successToast(color : string, mensaje : string) {
    const success = await this.toastController.create({
      message: mensaje,
      color : color,
      buttons: [ 
        {
          icon: 'close',
          role: 'cancel'
        }
      ]
    });
    success.present();
  }


  async presentLoading() {
    const loading = await this.loadingController.create({
      spinner: "bubbles",
      duration: 100000,
      message: 'Cargando ...',
      translucent: true,
      cssClass: 'custom-class custom-loading',
    });
    loading.present();
  }


}
