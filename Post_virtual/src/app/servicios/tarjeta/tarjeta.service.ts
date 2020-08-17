import { Injectable } from '@angular/core';
import { Tarjeta } from '../../models/tarjeta.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TarjetaService {

  tarjetas: Tarjeta[] = [];

  constructor(
    public http: HttpClient
  ) { }

  getVacio() {

    return [...this.tarjetas];

  }

  getTarjetas(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoTarjetas';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }

  infoTarjeta(idtarjeta: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoTarjeta';

    let data = {
      "id" : idtarjeta
    };

    return this.http.post(url, data);

    
  
  }

  obtenerTarjetas(){

    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('IdUsuario', localStorage.getItem('idUsuario'));

    return this.http.get('http://monyucab.somee.com/api/Dashboard/Tarjetas', {params: param, headers: header})
  }
}
