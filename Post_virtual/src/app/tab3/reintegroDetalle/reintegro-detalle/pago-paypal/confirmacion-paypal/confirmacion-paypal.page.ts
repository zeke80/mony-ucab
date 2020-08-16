import { Component, OnInit } from '@angular/core';
import { PagoService } from 'src/app/servicios/pago/pago.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-confirmacion-paypal',
  templateUrl: './confirmacion-paypal.page.html',
  styleUrls: ['./confirmacion-paypal.page.scss'],
})
export class ConfirmacionPaypalPage implements OnInit {

  constructor(private pagoService:PagoService,
              private router:Router
    
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
    this.router.navigate(['/tabs/cuenta']); 
  }

  cancelarPagoPaypal(){
    
  }

  ngOnInit() {
  }

}
