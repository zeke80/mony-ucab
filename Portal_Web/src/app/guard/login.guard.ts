import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

import { LoginService } from './../home/login-form/services/login.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {

  constructor(private router : Router, private s_login : LoginService) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    const helper = new JwtHelperService();
    var token = localStorage.getItem('token');

    if(token != null && !helper.isTokenExpired(token) && this.s_login.isLogged()) {
      return true;
    } else {
      if(helper.isTokenExpired(token)) // Prueba para verificar que el token expira
        console.log('Token expired!'); // Prueba para verificar que el token expira
      
      localStorage.clear();
      this.router.navigate(['/login']);
      return false;
    }
    
  }
  
}
