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
import { Router } from '@angular/router';


@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page implements OnInit {

  usuario: Usuario;
  comercio: Comercio;
  perfil: Perfil[] = [];

  user = {
    "result": {
        "idUsuario": null,
        "idEntity": ' ',
        "usuario": ' ',
        "fechaRegistro": {
            "dayOfYear": null,
            "year": null,
            "month": null,
            "day": null,
            "dayOfWeek": null,
            "isLeapYear": false,
            "isInfinity": false,
            "isNegativeInfinity": false,
            "isFinite": false
        },
        "nroIdentificacion": null,
        "email": '',
        "telefono": '',
        "direccion": '',
        "estatus": null,
        "contrasena": '',
        "idTipoUsuario": null
    },
    "tipoIdentificacion": {
        "idTipoIdentificacion": null,
        "codigo": '',
        "descripcion": '',
        "estatus": null
    },
    "persona": {
        "nombre": '',
        "apellido": '',
        "fechaNacimiento": {
            "dayOfYear": null,
            "year": null,
            "month": null,
            "day": null,
            "dayOfWeek": null,
            "isLeapYear": false,
            "isInfinity": false,
            "isNegativeInfinity": false,
            "isFinite": false
        }
    },
    "estadoCivil": {
        "idEstadoCivil": null,
        "descripcion": '',
        "codigo": '',
        "estatus": null
    },
    "comercio": {
        "razonSocial": '',
        "nombreRepresentante": '',
        "apellidoRepresentante": ''
    }
}



  constructor(
    public _usuarioService: UsuarioService,
    public _comercioService: ComercioService,
    public _loginServices: LoginService,
    public alert: AlertController,
    public router: Router
  ) {
  }

  ngOnInit(){

    this._usuarioService.getDatosPerfil().subscribe(
      (data: any) => {

       
      },
      
    );

     this._usuarioService.getDatosUsuario().subscribe(
      (res: any)=>{
        this.user = res;
      },
      (err:any)=>{

      }
    );
    }


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

  async onSubmit(){
    //await this.presentLoading();
    this._usuarioService.modificarUsaurio(this.user).subscribe(
      (res:any) => {
       // this.loadingController.dismiss();

        //this.successToast('success', 'Datos modificados satisfactioamente')

        this.router.navigate(['/tabs/cuenta']);
        console.log(this.user.estadoCivil.idEstadoCivil)
      },
      err => {
        //this.loadingController.dismiss();
        //this.presentToast('danger', 'Ha ocurrido un error al enviar el formulario');
      }
    );
  }



}
