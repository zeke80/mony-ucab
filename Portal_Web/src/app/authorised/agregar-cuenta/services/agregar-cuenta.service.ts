import { Globals } from './../../../common/globals';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AgregarCuentaService {
  show = false;

  readonly baseURI = Globals.API_URL;
  

  constructor(private http : HttpClient) { }

  agregarCuenta(numero : number, idTipoCuenta : number, idBanco : number){
   
    let url =  Globals.API_URL + "Billetera/Cuenta";

    let id = parseInt(localStorage.getItem('userIntID'), 10);

    let body = {
      "idUsuario": id,
      "idTipoCuenta":idTipoCuenta,
      "idBanco":idBanco,
      "numero": numero
    }

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    return this.http.post(url, body, {headers : header });
  }

  consultarBanco(){
    let url =  Globals.API_URL + "dashboard/Bancos";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')});

    return this.http.get(url,{headers : header});
  }


}
