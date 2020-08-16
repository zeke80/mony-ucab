import { Component, OnInit } from '@angular/core';
import { PagoService } from 'src/app/servicios/pago/pago.service';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ReintegroService } from 'src/app/servicios/reintegro/reintegro.service';

@Component({
  selector: 'app-confirmacion-paypal',
  templateUrl: './confirmacion-paypal.page.html',
  styleUrls: ['./confirmacion-paypal.page.scss'],
})
export class ConfirmacionPaypalPage implements OnInit {

  constructor(private pagoService:PagoService,
              private router:Router,
              private toastController:ToastController,
              private reintegroService:ReintegroService
    ) { }

  ejecutarPagoPaypal(){
    //console.log(localStorage.getItem('payId'));
    var body={
      "reg" : false,
      "idOperacion" : parseInt(localStorage.getItem('idReintegroDetalle')),
      "idPago" : localStorage.getItem('payId'),
      "idUsuarioPagante" : localStorage.getItem('accountId')
    }


    console.log(body);

    this.pagoService.ejecutarPagoPaypal(body).subscribe(
      (data: any) =>
      {
        console.log(data);
      },
      err =>{
        console.log(err);
        
      }
    ); 
    this.successToast('success', 'reintegro realizado satisfactoriamente');
    this.router.navigate(['/tabs/cuenta']); 
  }

  cancelarPagoPaypal(){
    
    var body = parseInt(localStorage.getItem('idReintegroDetalle'));

    this.reintegroService.cancelarReintegro(body).subscribe(
      (data: any) =>
      {
        console.log(data);
      },
      err =>{
        console.log(err);
        
      }
    );
    this.dangerToast('danger', 'Reintegro cancelado ');
    this.router.navigate(['/tabs/cuenta']); 
  }

  ngOnInit() {
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



}
