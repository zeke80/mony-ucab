import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { LoginService } from '../servicios/login/login.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  constructor(
    public _loginService: LoginService,
    public router: Router
  )
  {
  }

  canActivate(): boolean {
  if (localStorage.getItem('guard') === 'true'){
  return true;
  }
  console.log('bloqueado por el guard');
  this.router.navigate(['/login']);

  }
}

