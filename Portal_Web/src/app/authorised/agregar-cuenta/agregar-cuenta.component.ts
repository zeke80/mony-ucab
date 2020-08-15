import { HttpErrorResponse } from '@angular/common/http';
import { AgregarCuentaService } from './services/agregar-cuenta.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-agregar-cuenta',
  templateUrl: './agregar-cuenta.component.html',
  styleUrls: ['./agregar-cuenta.component.css']
})
export class AgregarCuentaComponent implements OnInit {

  numero : number  = null;
  idTipoCuenta;
  bancoId : number  = null;
  bancos : any;

  constructor(public s_cuenta :AgregarCuentaService) { }

  ngOnInit(): void {
    this.getBancos();
  }

  getBancos(){
    this.s_cuenta.consultarBanco().subscribe(
      data => {
        this.bancos = data;
      },
      (err : HttpErrorResponse) =>{
        if (err.status == 400){
          alert("Error en los datos")
        }
        else {
          alert ("Error inesperado. Intente de nuevo")
        }
      }

    );
  }

  agregarCuenta(){
    var id = parseInt(this.idTipoCuenta,10);
    this.s_cuenta.agregarCuenta(this.numero, id , this.bancoId).subscribe(
      (data: any) =>{
        alert(data.message);
      },
      (err : HttpErrorResponse) =>{
        if (err.status == 400){
          alert("Error en los datos")
        }
        else {
          alert ("Error inesperado. Intente de nuevo")
        }
      }
    );
  }

}
