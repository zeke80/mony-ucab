import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Globals } from 'src/app/common/globals';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginState = new BehaviorSubject(false);

  readonly baseURI = Globals.API_URL;

  constructor(private http: HttpClient) { }

  loginPersona(email: string, contrasena: string) {
    let url = this.baseURI + "Authentication/Login";
    return this.http.post(url, {usuario: '', email: email, password: contrasena, comercio: false});
  }

  loginComercio(email: string, contrasena: string){
    let url = this.baseURI + "Authentication/Login";
    return this.http.post(url, {usuario: '', email: email, password: contrasena, comercio: true});
  }

  getUserInfo(username){
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    return this.http.get(this.baseURI + 'Dashboard/InformacionPersona?Usuario='+username, {headers: tokenHeader});
  }

  guardarUsuario(data) {
      /* 
        localStorage.setItem('idUsuario', idUsuario.toString());
        localStorage.setItem('idTipoUsuario', idTipoUsuario.toString());
        localStorage.setItem('idTipoIdentificacion', idTipoIdentificacion.toString());
        localStorage.setItem('usuario', usuario);
      */
        localStorage.setItem('token', data.result.token);
        localStorage.setItem('userID', data.result.userID);
        localStorage.setItem('username', data.result.username);
        localStorage.setItem('email', data.result.email);     
  }

  isLogged(){
    return this.loginState.value;
  }

  login(){
    this.loginState.next(true);
  }

  logout(){
    this.loginState.next(false);
  }
}
