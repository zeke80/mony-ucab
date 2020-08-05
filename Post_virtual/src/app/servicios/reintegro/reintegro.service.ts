import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})


export class ReintegroService { 

  basic = 'Bearer ' +localStorage.getItem('token');

  suma = parseInt(localStorage.getItem('idUsuario')) + 1;
  common = this.suma.toString(this.suma);


  constructor(private http: HttpClient) { }

  reintegrosActivos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', this.common)
    return this.http.get('http://localhost:49683/api/Dashboard/ReintegrosActivos', {params: param, headers: header})
  }

  reintegrosCancelados(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', this.common)
    return this.http.get('http://localhost:49683/api/Dashboard/ReintegrosCancelados', {params: param, headers: header})
  }

  reintegrosExitosos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', this.common)
    return this.http.get('http://localhost:49683/api/Dashboard/ReintegrosExitosos', {params: param, headers: header})
  }

  cancelarReintegro(IdReintegro){
    console.log(IdReintegro);
    console.log(localStorage.getItem('token'));
    
    const header = new HttpHeaders({
      'Authorization': this.basic
    });

    let param = new HttpParams().set('IdReintegro', IdReintegro);


    const options = {
      headers: header,
      params: param
    };

    console.log(options);

    return this.http
    .post('http://localhost:49683/api/Transfer/CancelarReintegro',null, options)
  }




}

