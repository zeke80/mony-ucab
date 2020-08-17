import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';

@Injectable({
  providedIn: 'root'
})
export class RecuperarContrasenaService {

  constructor(private http : HttpClient) { }

  readonly baseURI = Globals.API_URL;

  recuperContrasena(email : string){
    let url = this.baseURI + "Authentication/ForgotPasswordEmail";
    return this.http.post(url, {email : email});
  }

}
