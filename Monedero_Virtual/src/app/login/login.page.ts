import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { LoginService } from '../servicios/login/login.service';
import { Usuario } from '../models/usuario.model';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  aux = false;
  formModel = {
    Email : '',
    Password : ''
  }

  constructor(public router: Router,
              public _usuarioServices: UsuarioService,
              public _loginServices: LoginService,
              public alert: AlertController,
    ) { }

ngOnInit() {
}

ingresar( f: NgForm ) {
    let userM: string = f.value.user.toUpperCase();
    var body = {
      UserName: '',
      Email: f.value.user,
      Password: f.value.password,
      comercio: this.aux
    };
    // this._loginServices.verificarUsuario(userM, f.value.password)
    //   .subscribe((data: any) => {

    //     this._loginServices.login();

    //   let usuario = new Usuario(data.idusuario, data.idtipousuario, data.idtipoidentificacion, data.usuario, data.fecha_registro,
    //     data.nro_identificacion, data.email, data.telefono, data.direccion, data.estatus);
    //   this._usuarioServices.guardarStorage(usuario, usuario.idUsuario, usuario.idTipoUsuario, usuario.usuario, usuario.fechaRegistro,
    //     usuario.nroIdentificacion, usuario.email, usuario.telefono, usuario.direccion);
    //   this.router.navigate(['/tabs/cuenta']);

    // },
    // (error: HttpErrorResponse) => {
    //   if (error.status === 409) {
    //     this.AlertServer();
    //   }
    //   else {
    //     this.AlertaError();
    //   }
    // });

    this._loginServices.ingresar(body)
        .subscribe((data: any) => {
          console.log(data.result.username)
          console.log(data.result.token)
          localStorage.setItem('token', data.result.token);
          this._usuarioServices.getUserInfo(data.result.username)
              .subscribe((data: any) => {
                console.log(data);
              })
        })

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
    let correoMay: string = email.toUpperCase();
    console.log(correoMay);
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
