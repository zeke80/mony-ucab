import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginState = new BehaviorSubject(false);

  constructor(private http: HttpClient) { }

  loginPersona(usuario:String, contrasena:String){
    let url= "http://monyucab.somee.com/api/Usuario/loginPersona";
  

    return this.http.post(url, {"user": usuario, "contra": contrasena});
  }

  loginComercio(usuario:String, contrasena:String){
    let url= "http://monyucab.somee.com/api/Usuario/loginComercio";


    return this.http.post(url, {user: usuario, contra: contrasena});
  }

  guardarUsuario(
     idUsuario : number,
     idTipoUsuario : number,
     idTipoIdentificacion : number,
     usuario : string){

        localStorage.setItem('idUsuario', idUsuario.toString());
        localStorage.setItem('idTipoUsuario', idTipoUsuario.toString());
        localStorage.setItem('idTipoIdentificacion', idTipoIdentificacion.toString());
        localStorage.setItem('usuario', usuario);
     
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
