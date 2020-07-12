import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { LoginService } from '../servicios/login/login.service';
import { Usuario } from '../models/usuario.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  aux = false;

  constructor(public router: Router,
              public _loginServices: LoginService,
              public _usuarioServices: UsuarioService,
              public alert: AlertController,
              ) { }

  ngOnInit() {
  }

  ingresar( f: NgForm ) {
    let userM: string = f.value.user.toUpperCase();
    this._loginServices.verificarUsuario(userM, f.value.password)
              .subscribe((data: any) => {

               let fecha =  data.fecha_registro.split('T', 1);

               this._loginServices.login();

              let usuario = new Usuario(data.idusuario, data.idtipousuario, data.idtipoidentificacion, data.usuario, fecha,
                data.nro_identificacion, data.email, data.telefono, data.direccion, data.estatus);
              this._usuarioServices.guardarStorage(usuario, usuario.idUsuario, usuario.idTipoUsuario, usuario.usuario, usuario.fechaRegistro,
                usuario.nroIdentificacion, usuario.email, usuario.telefono, usuario.direccion);
              this.router.navigate(['/tabs/cuenta']);

            },
            (error: HttpErrorResponse) => {
              if (error.status === 409) {
                this.AlertServer();
              }
              else {
                this.AlertaError();
              }
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
