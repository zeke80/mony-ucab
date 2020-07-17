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

    let url: string = 'http://monyucab.somee.com/api/Usuario/loginComercio';

    let data = {
      "user" : user,
      "contra" : contra
    };

    return this.http.post(url, data);

  }


  iniciarSesion(loginForm){
    return this.http.post('http://localhost:49683/api/Authentication/Login', loginForm)
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

}
