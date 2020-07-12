import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InicioService {

  show = true; 
  
  constructor(private http : HttpClient) { }

  consultarSaldo(){
    let url = "http://monyucab.somee.com/api/Usuario/saldo"

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});

  }
}
