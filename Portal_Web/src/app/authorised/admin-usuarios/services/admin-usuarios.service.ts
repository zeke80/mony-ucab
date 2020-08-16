import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminUsuariosService {

  show: boolean = false;
  readonly baseURI = Globals.API_URL;
  
  constructor(private http : HttpClient) { }

  consultarUsuarios() {
    let url = this.baseURI + "Admin/ConsultaUsuarios";
    let param = new HttpParams().set('query', 'WHERE estatus = 1');
    let header = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.get(url, {params : param, headers : header});
  }

  deleteUsuarios(usuario, idUsuario) {
    let url = this.baseURI + "Admin/EliminarUsuario";
    let param = new HttpParams().set('idUsuario', idUsuario).set('usuario', usuario);
    let header = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.delete(url, {params : param, headers : header});
  }
  
}
