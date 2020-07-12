import { HttpErrorResponse } from '@angular/common/http';
import { AgregarCuentaService } from './services/agregar-cuenta.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-agregar-cuenta',
  templateUrl: './agregar-cuenta.component.html',
  styleUrls: ['./agregar-cuenta.component.css']
})
export class AgregarCuentaComponent implements OnInit {

  nombre = '';
  numero = null;
  descripcion = '';

  constructor(public s_cuenta :AgregarCuentaService) { }

  ngOnInit(): void {
  }

  agregarCuenta(){
    this.s_cuenta.agregarCuenta(this.nombre, this.numero, this.descripcion).subscribe(
      (data: any) =>{
      },
      (err : HttpErrorResponse) =>{
        if (err.status == 400){
          alert("Error en los datos")
        }
        else if(err.status == 200){
          alert("Cuenta agregada")
        }
        else {
          alert ("Error inesperado. Intente de nuevo")
        }
      }
    );
  }

}
