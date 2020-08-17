import { Globals } from './../../../common/globals';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EstablecerComisionService {

  show = false;
  readonly baseURI = Globals.API_URL;
  id = localStorage.getItem('userIntID');
  
  constructor(  private http : HttpClient) { 
  }

  consultarComercio() {
    let url = this.baseURI + "Admin/ConsultaUsuarios";
    let param = new HttpParams().set('query', 'WHERE Usuario.idUsuario = Comercio.idUsuario AND  Usuario.estatus = 1');
    let header = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.get(url, {params : param, headers : header});
  }

  setComision(idComercio : string, comision : string){ 

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    let param = new HttpParams().set('idComercio',idComercio).set('comision', comision);
    let url = this.baseURI + "Admin/EstablecerComision";

    console.log("peticion", param);

    return this.http.post(url, null, {headers : header, params : param});
  }

  

}