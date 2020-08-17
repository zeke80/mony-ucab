import { Globals } from './../../../common/globals';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AgregarTarjetaService {

  show = false;
  readonly baseURI = Globals.API_URL;

  constructor(private http: HttpClient) { }

  agregarTarjeta(idTipoTarjeta: number, idBanco : number, numero : number, ano : number, mes: number, dia : number, cvc: number){
    let url =  Globals.API_URL + "Billetera/Tarjeta";

    let id = parseInt(localStorage.getItem('userIntID'), 10);
    
    let body ={
      "idUsuario": id,
      "idTipoTarjeta":idTipoTarjeta,
      "idBanco":idBanco,
      "numero":numero,
      "ano":ano,
      "mes":mes,
      "dia":dia,
      "cvc": cvc,
      "estatus":1
     };

     let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
     return this.http.post(url, body, {headers : header });

  }

  consultarBanco(){
    let url =  Globals.API_URL + "dashboard/Bancos";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')});

    return this.http.get(url,{headers : header});
  }
}
