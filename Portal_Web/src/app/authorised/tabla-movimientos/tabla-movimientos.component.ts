import { InicioService } from './../pantalla-inicio/services/inicio.service';
import { HttpErrorResponse } from '@angular/common/http';
import { MovimientosService } from './services/movimientos.service';
import { Component, OnInit } from '@angular/core';
import { Cobro } from 'src/app/models/cobro.model';

@Component({
  selector: 'app-tabla-movimientos',
  templateUrl: './tabla-movimientos.component.html',
  styleUrls: ['./tabla-movimientos.component.css']
})
export class TablaMovimientosComponent implements OnInit {

  
  userIntID = localStorage.getItem('userIntID');

  cobrosExitosos : any;
  cobrosCancelados : any;
  reintegrosActivos : any;
  reintegrosExitosos : any;
  reintegrosCancelados : any;
  movimientosCuenta : any;
  saldo : any;

  constructor(public s_movimientos : MovimientosService,
              private s_saldo : InicioService) { }

  ngOnInit(): void {
    this.s_movimientos.cobrosActivos().subscribe(
      (data : any) => {
        this.movimientosCuenta = data;
        console.log(this.movimientosCuenta);
      },
      (err : HttpErrorResponse) => {
        alert(err);
      }
    );
    this.s_movimientos.cobrosExitosos().subscribe(
      (data:any)=>{
        this.cobrosExitosos = data;
      },
      (err : HttpErrorResponse) =>{
        alert(err);
      }
    );
    this.s_movimientos.cobrosCancelados().subscribe(
      (data:any)=>{
        this.cobrosCancelados = data;
      },
      (err : HttpErrorResponse) =>{
        alert(err);
      }
    );
    this.s_movimientos.reintegrosActivos().subscribe(
      (data:any)=>{
        this.reintegrosActivos = data;
      },
      (err : HttpErrorResponse) =>{
        alert(err);
      }
    );
    this.s_movimientos.reintegrosExitosos().subscribe(
      (data:any)=>{
        this.reintegrosExitosos = data;
      },
      (err : HttpErrorResponse) =>{
        alert(err);
      }
    );
    this.s_movimientos.reintegrosCancelados().subscribe(
      (data:any)=>{
        this.reintegrosCancelados = data;
      },
      (err : HttpErrorResponse) =>{
        alert(err);
      }
    );

    this.s_saldo.consultarSaldo(this.userIntID).subscribe(data => {
      this.saldo = data;
    },
    (err : HttpErrorResponse) =>{
      alert(err);
    });
  }

  fechaToString(fecha : any){    
    return fecha.year.toString() + '-' + fecha.month.toString() + '-' + fecha.day.toString();
  }




}
