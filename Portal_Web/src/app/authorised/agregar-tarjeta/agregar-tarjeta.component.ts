import { HttpErrorResponse } from '@angular/common/http';
import { AgregarTarjetaService } from './services/agregar-tarjeta.service';
import { Component, OnInit } from '@angular/core';

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

  constructor(public s_tarjeta : AgregarTarjetaService) { }

  ngOnInit(): void {
  }

  antesEnviar(){
    if (parseInt(this.tipo, 10) == 1){
      this.tipo = 'DEBITO'
    }
    else if (parseInt(this.tipo, 10) == 1){
      this.tipo = 'CREDITO'
    }

    if(parseInt(this.banco) == 1){
      this.banco = 'MERCANTIL';
    }
    else if( parseInt(this.banco) == 2) {
      this.banco = 'BOD';
    }
    else if( parseInt(this.banco) == 3) {
      this.banco ='BANCO DE VENEZUELA';
    }
    else if( parseInt(this.banco) == 4) {
      this.banco ='BANCARIBE';
      
    }
     else if( parseInt(this.banco) == 5) {
      this.banco = 'BANCO PLAZA';
    }
    else if( parseInt(this.banco) == 6) {
      this.banco = 'BANCO BICENTENARIO';
    }
  }

  agregarTarjeta(){
    this.antesEnviar();
    this.s_tarjeta.agregarTarjeta(parseInt(this.numero,10), this.fecha_vencimiento, parseInt(this.cvc,10), 
    this.tipo, this.banco).subscribe(
      (data : any) =>{
      },
      (err : HttpErrorResponse) => {
        if (err.status == 400){
          alert ("Datos incorrectos. Vuelva a intentar")
        }
        else if (err.status == 200){
          alert("Tarjeta Agregada")
        }
        else {
          alert ("Error inesperado. Vuelva a intentar")
        }
      }
    );
  }

}
