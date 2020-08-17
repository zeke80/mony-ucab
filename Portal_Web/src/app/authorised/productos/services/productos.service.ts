import { Globals } from './../../../common/globals';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

    show = false;
    readonly baseURI = Globals.API_URL;
    
  constructor( private http: HttpClient) { }

  getTarjetas(){
    let url =  Globals.API_URL + "dashboard/Tarjetas";

    let id = localStorage.getItem('userIntID');

    let param = new HttpParams().set('IdUsuario', id);

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    
    return this.http.get(url, {params : param, headers : header});

  }

  getCuentas(){
    let url =  Globals.API_URL + "dashboard/Cuentas";

    let id = localStorage.getItem('userIntID');

    let param = new HttpParams().set('IdUsuario', id);

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.get(url, {params : param, headers : header});
  }


}
