import { Injectable } from '@angular/core';
import { Globals } from './../../../common/globals';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EstablecerLimiteService {

  show = false;
  
  readonly baseURI = Globals.API_URL;
  id = localStorage.getItem('userIntID');
  
  constructor( private http : HttpClient) { 
  }

  setComision(){

    let url = this.baseURI + "Admin/EstablecerLimiteParametro";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 

    let body = {
      "limite" : "10",
      "idParametro" : 1,
      "idUsuario" : 4
    };

    return this.http.post(url, body, {headers : header })
  }

  getParametro(){
    let url = this.baseURI + "dashboard/Parametros";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 

    return this.http.get(url, {headers : header})

  }
}