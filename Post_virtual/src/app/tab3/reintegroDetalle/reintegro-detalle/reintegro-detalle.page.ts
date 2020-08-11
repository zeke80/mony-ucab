import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReintegroService } from 'src/app/servicios/reintegro/reintegro.service';
import { AlertController, ToastController } from '@ionic/angular';

@Component({
  selector: 'app-reintegro-detalle',
  templateUrl: './reintegro-detalle.page.html',
  styleUrls: ['./reintegro-detalle.page.scss'],
})
export class ReintegroDetallePage implements OnInit {

  reintegroDetalle = {
    "idReintegro": null,
    "idUsuarioSolicitante": null,
    "fecha": {
        "year": null,
        "month": null,
        "day": null,
    },
    "monto": null,
    "estatus": '',
    "referencia": ''
  }

  constructor(
    private router: Router,
    private reintegroService: ReintegroService,
    private alert: AlertController,
    private toastController: ToastController
    ) { }

  setDetalle(){
   this.reintegroDetalle.idReintegro = localStorage.getItem('idReintegroDetalle');
   this.reintegroDetalle.idUsuarioSolicitante = localStorage.getItem('idUsuarioSolicitanteDetalle');
   this.reintegroDetalle.fecha.day = localStorage.getItem('diaDetalle');
   this.reintegroDetalle.fecha.month = localStorage.getItem('mesDetalle');
   this.reintegroDetalle.fecha.year = localStorage.getItem('anoDetalle');
   this.reintegroDetalle.monto = localStorage.getItem('montoDetalle');
   this.reintegroDetalle.estatus = localStorage.getItem('estatusDetalle');
   this.reintegroDetalle.referencia = localStorage.getItem('referenciaDetalle');
  }

getUser(){
  
}
pagoMonedero(){
  var body = {
    "idUsuarioReceptor":2,
    "idMedioPaga":1,
    "monto":100,
    "idOperacion":2
  }
  
  body.idUsuarioReceptor = parseInt(localStorage.getItem('idUsuarioSolicitanteDetalle'));
  body.idMedioPaga = parseInt(localStorage.getItem('idUsuario'));
  body.monto = parseInt(localStorage.getItem('montoDetalle'));
  body.idOperacion  = parseInt(localStorage.getItem('idReintegroDetalle'));
  
  this.reintegroService.pagarReintegroMonedero(body).
  subscribe(
    (data: any) =>
    {
      this.successToast('success', 'reintegro realizado satisfactoriamente');
      console.log(data);
      this.router.navigate(['/tabs/cuenta']);
    },
    err =>{
      console.log(err);
      
      this.dangerToast('danger', 'ERROR! reintegro no realizado ');    }
  )
}

pagoPaypal(){
  this.router.navigate(['tabs/operaciones/reintegro-detalle/pago-paypal']);
}

pagoStripe(){
  this.router.navigate(['tabs/operaciones/pago']);
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

async dangerToast(color : string, mensaje : string) {
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

  ngOnInit() {
    this.setDetalle();
    //hay que poner el email del usuario, aca hay solo el id del usuario oslicitante
    
  }

}
