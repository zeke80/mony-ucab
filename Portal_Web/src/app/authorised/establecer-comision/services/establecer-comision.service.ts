import { AdminUsuariosService } from './../../admin-usuarios/services/admin-usuarios.service';
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
  
  constructor(  private http : HttpClient,
                private s_admin :AdminUsuariosService) { 
  }

  setComision(idComercio : string, comision : string){ 

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    let param = new HttpParams().set('idComercio',idComercio).set('comision', comision);
    let url = this.baseURI + "Admin/EstablecerComision";

    return this.http.get(url, {params : param, headers : header});
  }

  getUsuarios(){
      this.s_admin.consultarUsuarios();
  }
  

}