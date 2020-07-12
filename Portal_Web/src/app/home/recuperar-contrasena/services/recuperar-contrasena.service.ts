import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RecuperarContrasenaService {

  constructor(private http : HttpClient) { }

  recuperContrasena(email : string){

    let url = "http://monyucab.somee.com/api/Usuario/enviarEmail";

    return this.http.post(url, {'email' : email});
  }
}
