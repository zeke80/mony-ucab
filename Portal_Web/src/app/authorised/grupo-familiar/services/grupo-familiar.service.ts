import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GrupoFamiliarService {

  show: boolean = false;
  readonly baseURI = Globals.API_URL;

  constructor(private http : HttpClient) { }

  getSubUsuarios() {
    let url = this.baseURI + "Dashboard/ConsultaUsuariosF";
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'));
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.get(url, {params : param, headers : header});
  }
}
