import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { LoginService } from '../servicios/login/login.service';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  formModel = {
    email : '',
    password : '',
    comercio: true
  }

  aux = false;

  constructor(public router: Router,
              public _loginServices: LoginService,
              public _usuarioServices: UsuarioService,
              public alert: AlertController,
              ) { }

  ngOnInit() {
  }

  ingresar( f: NgForm ) {
    console.log(this.formModel.email);
    this._loginServices.iniciarSesion(f.value)
              .subscribe((data: any) => {

                console.log(data.result.token);
                console.log(this.formModel.email);
                localStorage.setItem('token', data.result.token);
                localStorage.setItem('email', this.formModel.email);

              this.router.navigate(['/tabs/cuenta']);

            },
            (error: any) => {

              this.AlertServer();
              console.log(error);
            });
  }

  async AlertaError() {
    const alertElement = await this.alert.create({
      header: 'Error en login',
      message: 'Usuario y/o clave incorrectas ',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
            this.router.navigate(['/login']);
          }
        },

      ]
    });

    await alertElement.present();

  }

  async AlertServer() {
    const alertElement = await this.alert.create({
      header: 'Error inesperado',
      message: 'intentelo mas tarde',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
          }
        },

      ]
    });

    await alertElement.present();

  }

  cambiar() {
    this.aux = true;
  }

  recuperar(email: string) {
    console.log(email);
    let correoMay: string = email.toUpperCase();
    this._loginServices.recuperarUserContra(correoMay)
        .subscribe((data: any) => {
          this.correo();
        });
  }

  async correo() {
    const alertElement = await this.alert.create({
      header: 'Correo enviado',
      message: 'revisar la la informacion del correo',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
          }
        },

      ]
    });

    await alertElement.present();

  }

}
