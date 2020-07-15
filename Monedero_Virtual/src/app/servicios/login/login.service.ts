import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginState = new BehaviorSubject(false);

  constructor(
    public http: HttpClient
  ) { }

  verificarUsuario(user: string, contra: string) {

    let url: string = 'http://monyucab.somee.com/api/Usuario/loginPersona';

    let data = {
      "user": user,
      "contra": contra
    };

    return this.http.post(url, data);

  }

  login(){
    this.loginState.next(true);
  }

  estaLogueado() {
    return this.loginState.value;
  }

  logout() {
    this.loginState.next(false);
  }

  recuperarUserContra(email: string) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/enviarEmail';

    let data = {
      "email": email
    };

    return this.http.post(url, data);
  }

  // back nuevo

  ingresar(body) {
    return this.http.post('http://monyucab.somee.com/api/authentication/login', body);
  }

}
