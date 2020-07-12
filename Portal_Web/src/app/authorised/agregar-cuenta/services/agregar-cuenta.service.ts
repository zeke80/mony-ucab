import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AgregarCuentaService {
  show = false;

  constructor(private http : HttpClient) { }

  agregarCuenta( nombre : string, numero : number, descrip : string){
    let url = "http://monyucab.somee.com/api/Usuario/registrarCuentaBanco";

    let usuario = localStorage.getItem('usuario');

    return this.http.post(url, {
      'usuario': usuario,
      'nombre':  nombre,
      'numero':  numero,
      'descripcion': descrip
    });
  }
}
