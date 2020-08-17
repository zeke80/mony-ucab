import { HttpErrorResponse } from '@angular/common/http';
import { ProductosService } from './../productos/services/productos.service';
import { RetirarService } from './services/retirar.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-retirar-form',
  templateUrl: './retirar-form.component.html',
  styleUrls: ['./retirar-form.component.css']
})
export class RetirarFormComponent implements OnInit {

  saldo;
  cuentas : any;
  idCuenta = 0;
  monto = 0;
  

  constructor(public s_retirar : RetirarService,
              private s_prodcuto : ProductosService) { }

  ngOnInit(): void {
    this.getCuentas();
    this.getSaldo(); 
  }


  getSaldo(){
    this.s_retirar.getSaldo().subscribe(
      (data : any ) => {
        this.saldo = data;
      },
      (err :any) =>{
        console.log(err);
      }
    )
  }
  getCuentas(){
    this.s_prodcuto.getCuentas().subscribe(
      (data : any) => {
        this.cuentas = data;
      },
      (err : any) => {
        console.log(err);
      }
    )
  }

  retirar(){
    this.s_retirar.retirar(this.idCuenta,this.monto).subscribe(
      (data : any) =>{
        alert(data.message);
      },
      (err : HttpErrorResponse) => {
        if (err.status >= 400){
          alert("Error en datos o ha superado su limite")
        }
        else{
          alert("Error inesperado. Intente luego");
        }
      }
    )
  }

  onClickRetirar(){
    this.retirar();

    this.s_retirar.refreshInfo.subscribe(
      ()=> {
        this.getSaldo();
      }
    );
  }


}
