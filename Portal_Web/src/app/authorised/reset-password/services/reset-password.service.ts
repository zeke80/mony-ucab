import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ResetPasswordService {

  constructor(private http: HttpClient) { }

  readonly BaseURI = Globals.API_URL;

  /*
  * FUNCION: resetPassword(formData)
  * DESCRIPCIÓN:
  * Envia al servidor el nuevo password confirmado junto al userID y al
  * hashed ResetPasswordToken mediante un POST request, usando el URL del 
  * correspondiente.
  */
  resetPassword(formData) {
    return this.http.post(this.BaseURI+'Authentication/ResetPassword', formData);
  }

}
