import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AgregarTarjetaService {

  show = false;

  constructor(private http: HttpClient) { }

  agregarTarjeta(numero : number, fecha : string, cvc : number, tipo : string, banco :string){
    let url = "http://monyucab.somee.com/api/Usuario/registrarTarjeta";

    let usuario = localStorage.getItem('usuario').toLocaleUpperCase();
    
    return this.http.post(url, {
      'numero' : numero,
      'fecha_vencimiento' : fecha,
      'cvc' : cvc,
      'tipotarjeta' : tipo,
      'banco' : banco,
      'user' :usuario
    })

  }
}
