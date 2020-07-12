import { HttpErrorResponse } from '@angular/common/http';
import { SignupService } from './services/signup.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

import { Persona } from './../../models/persona.model';
import { Comercio } from './../../models/comercio.model';
import { Usuario } from './../../models/usuario.model';
import { DatePipe } from '@angular/common';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-signup-form',
  templateUrl: './signup-form.component.html',
  styleUrls: ['./signup-form.component.css']
})
export class SignupFormComponent implements OnInit {

  showCards = true;
  showPersona = false;
  showComercio = false;
  showUsuario = false;

  idTipoUsuario = 0;  
  contrasena = '';


  formPersona = new FormGroup({
    nombre : new FormControl('', [Validators.pattern(/^([A-Za-z])*$/), Validators.required]),
    apellido : new FormControl ('',[Validators.pattern(/^([A-Za-z])*$/), Validators.required]),
    fechaNac : new FormControl ('', Validators.required),
    estadoCivil : new FormControl ('', Validators.required)
  });

  formComercio = new FormGroup({
    razonSocial : new FormControl('', Validators.required),
    nombreRepresentante : new FormControl ('', [Validators.pattern(/^([A-Za-z])*$/), Validators.required]),
    apellidoRepresentante : new FormControl('', [Validators.pattern(/^([A-Za-z])*$/), Validators.required])
  });

  formUsuario = new FormGroup({
    tipoId : new FormControl ('', Validators.required),
    numeroId : new FormControl('', [Validators.pattern(/^[0-9]*$/), Validators.required]),
    telefono : new FormControl ('', [Validators.pattern(/^[0-9]*$/), Validators.required]),
    correo : new FormControl ('', [Validators.email, Validators.required]),
    direccion : new FormControl ('', Validators.required),
    usuario : new FormControl ('', Validators.required),
    contra : new FormControl ('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required])
  }); 

  constructor(private s_signup : SignupService) { }

  ngOnInit(): void {
  }

  togglePersona(){
    this.showPersona = true;
    this.showUsuario = true;
    this.showCards = false;
    this.showComercio = false;
    this.idTipoUsuario = 1;
  }

  toggleComercio(){
    this.showComercio = true;
    this.showUsuario = true;
    this.showCards = false;
    this.showPersona = false;
    this.idTipoUsuario = 2;
  }

  registrarPersona(){

    var descripId = '';
    if(this.formUsuario.get('tipoId').value == 3){
      descripId = "pasaporte"
    }
    else if ((this.formUsuario.get('tipoId').value == 1) || (this.formUsuario.get('tipoId').value == 2)) {
      descripId = "cedula"
    }
    this.contrasena = this.formUsuario.get('contra').value;

    this.s_signup.registrarPersona(
        this.formUsuario.get('usuario').value,
        this.formPersona.get('nombre').value,
        this.formPersona.get('apellido').value,
        this.contrasena,
        this.formPersona.get('fechaNac').value,
        this.formUsuario.get('correo').value,
        this.formUsuario.get('telefono').value,
        this.formUsuario.get('direccion').value,
        parseInt(this.formUsuario.get('numeroId').value,10),
        "persona",
        1,
        parseInt(this.formUsuario.get('tipoId').value,10),
        descripId,
        parseInt(this.formPersona.get('estadoCivil').value,10))
    .subscribe(
      (data : any)=>{
      },
      (err : HttpErrorResponse) =>{
        if (err.error == 400){
          alert("Datos repetidos. Intente de nuevo");
        }
        else if (err.status == 200){
          alert("Persona creado");
        }
        else {
          alert("Error inesperado. Vuelva a intentar")
        }
      }
    );
  }

  registarComercio(){
    this.contrasena = this.formUsuario.get('contra').value;
    this.s_signup.registrarComercio(
      this.formUsuario.get('usuario').value,
      this.contrasena,
      this.formUsuario.get('correo').value,
      this.formUsuario.get('telefono').value,
      this.formUsuario.get('direccion').value,
      parseInt(this.formUsuario.get('numeroId').value,10),
      1,
      this.formComercio.get('razonSocial').value,
      this.formComercio.get('nombreRepresentante').value,
      this.formComercio.get('apellidoRepresentante').value
      ).subscribe((data: any)=>{
      },
      (err : HttpErrorResponse) =>{
        if (err.status == 400){
          alert("Datos duplicados. Intente nuevamente")
        }
        else if(err.status == 200){
          alert("Comercio creado")
        }
        else {
          alert("Error inesperado. Intente de nuevo")
        }
      });
  }

  enviar(){
    if (this.idTipoUsuario == 1){
      this.registrarPersona();
    }
    else{
      this.registarComercio();
    }
  }

  
}
