import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

  show = false;

  solicitante = '1';

  reintegroSolicitante = parseInt(this.solicitante + 1);
  idSolicitante = this.reintegroSolicitante.toString(this.reintegroSolicitante);

  constructor( private http : HttpClient) { }

  cobrosActivos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'))
    .set('solicitante', '1')
    return this.http.get('http://monyucab.somee.com/api/dashboard/CobrosActivos', {params: param, headers: header})
  }

  cobrosCancelados(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'))
    .set('solicitante', '1')
    return this.http.get('http://monyucab.somee.com/api/dashboard/CobrosCancelados', {params: param, headers: header})
  }

  cobrosExitosos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'))
    .set('solicitante', '1')
    return this.http.get('http://monyucab.somee.com/api/dashboard/CobrosExitosos', {params: param, headers: header})
  }


  reintegrosActivos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'))
    .set('solicitante', this.idSolicitante)
    return this.http.get('http://monyucab.somee.com/api/dashboard/ReintegrosActivos', {params: param, headers: header})
  }

  reintegrosCancelados(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'))
    .set('solicitante', this.idSolicitante)
    return this.http.get('http://monyucab.somee.com/api/dashboard/ReintegrosCancelados', {params: param, headers: header})
  }

  reintegrosExitosos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('userIntID'))
    .set('solicitante', this.idSolicitante)
    return this.http.get('http://monyucab.somee.com/api/dashboard/ReintegrosExitosos', {params: param, headers: header})
  }
  
  consultarCuentas(){
    let url = "http://monyucab.somee.com/api/Usuario/operacionesCuentas";

    let id = parseInt(localStorage.getItem('userIntID'), 10);
    
    return this.http.post(url, {'id' : id});
  }

  consultarTarjeta (){
    let url = "http://monyucab.somee.com/api/Usuario/operacionesTarjetas";
    
    let id = parseInt(localStorage.getItem('userIntID'), 10);

    return this.http.post(url, {'id' : id});
  }

  consutarMonedero (){
    let url = "http://monyucab.somee.com/api/Usuario/operacionesMonedero"

    let id = parseInt(localStorage.getItem('userIntID'), 10);

    return this.http.post(url, {'id' : id});
  }


}
