import { HttpErrorResponse } from '@angular/common/http';
import { MovimientosService } from './services/movimientos.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tabla-movimientos',
  templateUrl: './tabla-movimientos.component.html',
  styleUrls: ['./tabla-movimientos.component.css']
})
export class TablaMovimientosComponent implements OnInit {

  movimientosCuenta : any;
  movimientosTarjeta : any;
  movimientosMonedero : any;
  saldo : any;
  mes1 : number = null;
  mes2 : number  = null;
  anio : number = null;
  opcion : string;
  fecha1 : string = null; 
  fecha2 : string = null;

  constructor(public s_movimientos : MovimientosService) { }

  ngOnInit(): void {
    this.s_movimientos.consultarCobros().subscribe(
      (data : any) => {
        this.movimientosCuenta = data;
        console.log(this.movimientosCuenta);
      },
      (err : HttpErrorResponse) => {
        alert(err);
      }
    )
  }

  fechaToString(fecha : any){    
    return fecha.year.toString() + '-' + fecha.month.toString() + '-' + fecha.day.toString();
    ;
  }

  
  filtrar(){
    if ((this.fecha1 != null) && (this.fecha2 != null)){
      if (this.opcion == "tarjeta"){
        this.filtrarTarjeta(this.fecha1, this.fecha2);
      }else if (this.opcion == "monedero"){
        this.filtrarMonedero(this.fecha1, this.fecha2);
      } else if (this.opcion == "cuenta"){
        this.filtrarCuenta(this.fecha1, this.fecha2);
      }
    } else{
      if (this.opcion == "todos"){
        this.consultarTodo();
      }
      else if (this.opcion == "tarjeta"){
        this.consultarSoloTarjeta();
      }
      else if (this.opcion == "monedero"){
        this.consultarSoloMonedero();
  
      }
      else if (this.opcion == "cuenta"){
        this.consultarSoloCuenta();
      };
    };
  }

  consultarTodo(){
    this.s_movimientos.consultarCuentas().subscribe(data =>{
      this.movimientosCuenta = data;
    });

    this.s_movimientos.consultarTarjeta().subscribe(data =>{
      this.movimientosTarjeta = data;
    });

    this.s_movimientos.consutarMonedero() .subscribe(data =>{
      this.movimientosMonedero = data;
    });

    this.s_movimientos.consultarSaldo().subscribe(data => {
      this.saldo = data;
    });
    
  }
  consultarSoloTarjeta(){
    this.s_movimientos.consultarTarjeta().subscribe(data =>{
      this.movimientosTarjeta = data;
    });

    this.movimientosCuenta = null;

    this.movimientosMonedero = null;
  }

  consultarSoloMonedero(){

    this.s_movimientos.consutarMonedero() .subscribe(data =>{
      this.movimientosMonedero = data;
    });

    this.movimientosCuenta = null;
    
    this.movimientosTarjeta = null;
  }


  consultarSoloCuenta(){

    this.s_movimientos.consultarCuentas().subscribe(data =>{
      this.movimientosCuenta = data;
    });

    this.movimientosMonedero = null;

    this.movimientosTarjeta = null;
  }

  filtrarCuenta(fecha1 : string, fecha2 : string){
    this.movimientosCuenta = null;
    this.s_movimientos.consultarCuentasParam(fecha1,fecha2).subscribe(
      data => {this.movimientosCuenta = data}
    );
    this.movimientosMonedero = null;
    this.movimientosTarjeta = null;
  }

  filtrarMonedero(fecha1 : string, fecha2 : string){
    this.movimientosCuenta = null;
    this.movimientosMonedero = null;
    this.movimientosTarjeta = null;
    this.s_movimientos.consutarMonederoParam(fecha1,fecha2).subscribe(
      data => {this.movimientosMonedero = data}
    );
  }

  filtrarTarjeta(fecha1 : string, fecha2 : string){
    this.movimientosCuenta = null;
    this.movimientosMonedero = null;
    this.movimientosTarjeta = null;
    this.s_movimientos.consultarTarjetaParam(fecha1,fecha2).subscribe(
      data => {this.movimientosTarjeta = data}
    );
  }


}
