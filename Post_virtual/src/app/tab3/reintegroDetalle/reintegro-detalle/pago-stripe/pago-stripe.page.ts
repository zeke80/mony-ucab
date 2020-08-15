import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastController, LoadingController, AlertController } from '@ionic/angular';

@Component({
  selector: 'app-pago-stripe',
  templateUrl: './pago-stripe.page.html',
  styleUrls: ['./pago-stripe.page.scss'],
})
export class PagoStripePage implements OnInit {

  constructor(private router: Router) { }

  Pago(){
    this.router.navigate(['tabs/operaciones/reintegro-detalle/pago-stripe/confirmacion-stripe'])
  }

  ngOnInit() {
  }

}
