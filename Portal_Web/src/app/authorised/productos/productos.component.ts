import { HttpErrorResponse } from '@angular/common/http';
import { AgregarTarjetaService } from './../agregar-tarjeta/services/agregar-tarjeta.service';
import { AgregarCuentaService } from './../agregar-cuenta/services/agregar-cuenta.service';
import { ProductosService } from './services/productos.service';
import { Component, OnInit, OnDestroy} from '@angular/core';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {

  tarjetas : any;
  cuentas : any;
  tipo : string;
  banco : string;

  constructor(public s_producto : ProductosService, public s_cuenta : AgregarCuentaService, public s_tarjeta : AgregarTarjetaService) { }

  ngOnInit(): void {
    this.getCuentas();
    this.getTarjetas();
  }

  agregarCuenta(){
    this.s_cuenta.show = true;
    this.s_producto.show = false;
  }

  agregarTarjeta(){
    this.s_tarjeta.show = true;
    this.s_producto.show = false;
  }

  ocultarAgregar(){
    this.s_tarjeta.show = false;
    this.s_cuenta.show = false;
    this.s_producto.show = true;
  }
  
  ocultarProductos(){
    this.s_cuenta.show = false;
    this.s_tarjeta.show = false;
  }

  
  getTarjetas(){
    this.s_producto.getTarjetas().subscribe(
      (data : any) => {
        this.tarjetas = data;
      },
      (err : HttpErrorResponse) =>{console.log(err)}
    );
  }

  getCuentas(){
    this.s_producto.getCuentas().subscribe(
      (data : any) => {
        this.cuentas = data;
      },
      (err : HttpErrorResponse) =>{console.log(err)}
    );
  }
}
