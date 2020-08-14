import { Component, OnInit } from '@angular/core';
import { LoginService } from './services/login.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http'; 

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  user: string;
  contra: string;

  constructor(public service: LoginService, public router: Router) { }

  ngOnInit(): void {

  }

  ingresarPersona() {
    this.service.loginPersona(this.user, this.contra)
    .subscribe(
      (data: any) => {
          this.service.login();
          this.service.guardarUsuario(data);
          this.getUserInfo();
          this.router.navigate(['/dashboard']);
    },
      (error : HttpErrorResponse) => {
        if (error.status == 404){
          alert("Usuario no encontrado.")
        }
        else{
          alert("Ha ocurrido un error. Intente de nuevo")
        }
      }
    );
  }

  ingresarComercio() {
    this.service.loginComercio(this.user, this.contra)
    .subscribe(
      (data: any) => {
          this.service.guardarUsuario(data);
          this.service.login();
          this.router.navigate(['/dashboard']);
    },
      (error : HttpErrorResponse) => {
        if (error.status == 404){
          alert("Usuario no encontrado.")
        }
        else{
          alert("Ha ocurrido un error. Intente de nuevo")
        }
      }
    );
  }

  getUserInfo() {
    this.service.getUserInfo(localStorage.getItem('username')).subscribe(
      (data:any) => {
        localStorage.setItem('userIntID', data.result.idUsuario);
      },
      error => {
        console.log(error);
      }
    );
  }

}
