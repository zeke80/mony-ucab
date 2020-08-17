import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AlertController } from '@ionic/angular';
import { PagoService } from 'src/app/servicios/pago/pago.service';
import { ReintegroService } from 'src/app/servicios/reintegro/reintegro.service';

@Component({
  selector: 'app-confirmacion-stripe',
  templateUrl: './confirmacion-stripe.page.html',
  styleUrls: ['./confirmacion-stripe.page.scss'],
})
export class ConfirmacionStripePage implements OnInit {

  constructor(private router: Router, 
    private formModulo: FormsModule,
    private alert: AlertController,
    private pagoService:PagoService,
    private reintegroService:ReintegroService) { }

    ejecutarPagoStripe(){

      var body = {"monto":0,
      "descripcion": "",
      "emailReceptor": "",
      "reg":false,
      "idOperacion": 0}

      body.monto = parseInt(localStorage.getItem('montoDetalle'));
      body.descripcion = localStorage.getItem('descripcionStripe');
      body.emailReceptor = localStorage.getItem('emailStripe');
      body.idOperacion = parseInt(localStorage.getItem('idReintegroDetalle'));

      this.pagoService.ejecutarPagoStripe(body).subscribe(

        (data: any) =>
    {
      
     console.log(data);
      },
      err => {
        console.log(err.message);
      }
      );
      this.router.navigate(['tabs/operaciones']);
    }

    cancelarPagoStripe(){
      this.router.navigate(['tabs/operaciones']);
    }

  ngOnInit() {
  }

}
