import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BloquearService {

  show = false;
  
  constructor(private http : HttpClient) { }

  consultarPagos(){
    let url = "http://monyucab.somee.com/api/Usuario/pagosSolicitadosSolicitante";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});
  }

}
