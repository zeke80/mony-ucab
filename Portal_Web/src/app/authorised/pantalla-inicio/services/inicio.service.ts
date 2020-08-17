import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';

@Injectable({
  providedIn: 'root'
})
export class InicioService {

  show = true; 
  
  constructor(private http : HttpClient) { }

  readonly baseURI = Globals.API_URL;

  consultarSaldo(userIntID: string){
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idusuario', userIntID);
    let url = this.baseURI + "Monedero/Consultar";

    return this.http.get(url, {params : param, headers : header});
  }
}
