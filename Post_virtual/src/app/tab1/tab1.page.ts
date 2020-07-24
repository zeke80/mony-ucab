import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Usuario } from '../models/usuario.model';
import { Comercio } from '../models/comercio.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { ComercioService } from '../servicios/comercio/comercio.service';
import { AlertController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
import { Perfil } from '../models/perfil.model';
import { LoginService } from '../servicios/login/login.service';


@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page implements OnInit {

  usuario: Usuario;
  comercio: Comercio;
  perfil: Perfil[] = [];

  nombre: string;
  apellido: string;
  telefono: string;
  direccion: string;
  razonsocial: string;
  email: string;


  constructor(
    public _usuarioService: UsuarioService,
    public _comercioService: ComercioService,
    public _loginServices: LoginService,
    public alert: AlertController
  ) {
  }

  ngOnInit(){

    this._usuarioService.getDatosPerfil().subscribe(
      (data: any) => {

        localStorage.setItem('name', data.persona.nombre);
        localStorage.setItem('apellido', data.persona.apellido);
        localStorage.setItem('telefono', data.result.telefono);
        localStorage.setItem('direccion', data.result.direccion);
        localStorage.setItem('razonsocial', data.comercio.razonSocial);

        this.nombre = localStorage.getItem('name');
        this.apellido = localStorage.getItem('apellido');
        this.telefono = localStorage.getItem('telefono');
        this.direccion = localStorage.getItem('direccion');
        this.razonsocial = localStorage.getItem('razonsocial');
        console.log(data);
      },
      
    );

     this._usuarioService.getDatosUsuario().subscribe(
      (res: any)=>{
        this.usuario = res;
      },
      (err:any)=>{

      }
    );
    /*this.usuario = this._usuarioService.getUsuario();
    this.comercio = this._comercioService.getVacio();
    this._comercioService.getComercio(this.usuario.idUsuario)
                  .subscribe((data: any) => {
                    this.comercio = data;
                  });*/
      
    //aca debe ir el servicio para buscar los datos de usuario

    
  }

  /*modificarUsuario( f: NgForm) {
    let ident: number = + f.value.identificacion;
    let correo: string = f.value.email.toUpperCase();
    let userMas: string = f.value.user.toUpperCase();

    this._comercioService.ajustarComercio(this.usuario.idUsuario, f.value.razon, f.value.nombre, f.value.apellido)
        .subscribe((data: any) => {
        });

    this._usuarioService.ajustarUsurio(this.usuario.idUsuario, userMas, ident, correo, f.value.telefono,
                                        f.value.direccion )
        .subscribe((data: any) => {
          this.modificado();
        },
        (error: HttpErrorResponse) => {
            this.AlertaError();
        });
  }*/

  async AlertaError() {
    const alertElement = await this.alert.create({
      header: 'Error al modificar usuario',
      message: 'El usuario y/o correo debe de ser unico ',
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

  async modificado() {
    const alertElement = await this.alert.create({
      header: 'Exito al modificar usuario',
      message: 'se modificaron los datos satisfactoriamente',
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
