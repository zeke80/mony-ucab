import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

    show = false;

  constructor( private http: HttpClient) { }

  consultarCuenta(){
    let url = "http://monyucab.somee.com/api/Usuario/infoCuentas";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});
  }

  consultarTarjeta(){
    let url = "http://monyucab.somee.com/api/Usuario/infoTarjetas";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});

  }
}
