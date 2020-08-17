import { HttpErrorResponse } from '@angular/common/http';
import { AgregarTarjetaService } from './services/agregar-tarjeta.service';
import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-agregar-tarjeta',
  templateUrl: './agregar-tarjeta.component.html',
  styleUrls: ['./agregar-tarjeta.component.css']
})
export class AgregarTarjetaComponent implements OnInit {

  numero =  null;
  fecha_vencimiento = '';
  cvc = null;
  tipo = '';
  banco = '';
  bancos : any ;

  constructor(public s_tarjeta : AgregarTarjetaService, private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.getBancos(); 
  }


  getBancos(){
    this.s_tarjeta.consultarBanco().subscribe(
      data => {
        this.bancos = data;
      },
      (err : HttpErrorResponse) =>{
        console.log(err);
      }

    );
  }

  agregarTarjeta(){
    this.s_tarjeta.agregarTarjeta(parseInt(this.tipo,10), 
                                  parseInt(this.banco,10), 
                                  parseInt(this.numero,10),
                                  parseInt(this.datePipe.transform(this.fecha_vencimiento,'yyyy'), 10),
                                  parseInt(this.datePipe.transform(this.fecha_vencimiento,'MM'), 10),
                                  parseInt(this.datePipe.transform(this.fecha_vencimiento,'dd'), 10),
                                  parseInt(this.cvc,10)
                                  ).subscribe(
      (data : any) =>{
        alert("Tarjeta Agregada");
      },
      (err : HttpErrorResponse) => {
        if (err.status == 400){
          alert ("Datos incorrectos. Vuelva a intentar")
        }
        else {
          alert ("Error inesperado. Vuelva a intentar")
        }
      }
    );
  }

}
