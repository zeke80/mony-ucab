import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfiguracionesService {

  show = false;
  
  constructor( private http : HttpClient) { 
  }

  cambiarContra( vieja : string,  nueva : string){
    let url = "http://monyucab.somee.com/api/Usuario/ActualizarPass";

    let usuario = localStorage.getItem('usuario').toLocaleUpperCase();

    let body = {
      "usuario": usuario,
      "viejacontra" : vieja,
      "nuevacontra" : nueva
    };

    return this.http.post(url, body);
  }
}
