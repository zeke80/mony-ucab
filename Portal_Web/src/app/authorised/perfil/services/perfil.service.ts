import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  show = false;
  
  constructor(private http : HttpClient) {
  }

  consultar(){

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + 
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIwM2M2MTQyYi03YzVhLTRhN2UtOTg5NC0yZWI3OWFlNjJiYmMiLCJMb2dnZWRPbiI6IjgvMTAvMjAyMCAyOjIyOjM4IEFNIiwibmJmIjoxNTk3MDUxMzU4LCJleHAiOjE1OTcwNTQwNTgsImlhdCI6MTU5NzA1MTM1OH0.1ovrAiDi0ElZJqQoodbNJjKYC2_tiIBEFtRCMshweQc"});
    let param = new HttpParams().set('Usuario', 'maria');
    let url ="http://monyucab.somee.com/api/dashboard/InformacionPersona";

    return this.http.get(url, {params : param, headers : header});

  }

  consultarEstadosCiviles(){
    let url = "http://monyucab.somee.com/api/dashboard/EstadosCiviles";
   
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + 
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIwM2M2MTQyYi03YzVhLTRhN2UtOTg5NC0yZWI3OWFlNjJiYmMiLCJMb2dnZWRPbiI6IjgvMTAvMjAyMCAyOjIyOjM4IEFNIiwibmJmIjoxNTk3MDUxMzU4LCJleHAiOjE1OTcwNTQwNTgsImlhdCI6MTU5NzA1MTM1OH0.1ovrAiDi0ElZJqQoodbNJjKYC2_tiIBEFtRCMshweQc"});
    return this.http.get(url, {headers : header});

  }

}
