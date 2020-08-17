import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastController, LoadingController, AlertController } from '@ionic/angular';

@Component({
  selector: 'app-pago-stripe',
  templateUrl: './pago-stripe.page.html',
  styleUrls: ['./pago-stripe.page.scss'],
})
export class PagoStripePage implements OnInit {

  pagoStripe =
  {"monto":0,
    "descripcion": "",
    "emailReceptor": "",
    "reg":false,
    "idOperacion": 0}

  constructor(private router: Router) { }

  onSubmit(){

    localStorage.setItem('descripcionStripe', this.pagoStripe.descripcion);
    localStorage.setItem('emailStripe', this.pagoStripe.emailReceptor);
    this.router.navigate(['tabs/operaciones/reintegro-detalle/pago-stripe/confirmacion-stripe'])
  }


  setPagoStripe(){

   this.pagoStripe.monto = parseInt(localStorage.getItem('montoDetalle'));
   this.pagoStripe.idOperacion = parseInt(localStorage.getItem('idReintegroDetalle'));
  }

  ngOnInit() {

    this.setPagoStripe();
    
  }

}
