import { Router } from '@angular/router';
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

  idTipoUsuario = 1;  
  contrasena = '';

  esPersona = true;


  formPersona = new FormGroup({
    nombre : new FormControl ('', Validators.required),
    apellido : new FormControl ('', Validators.required),
    fechaNac : new FormControl ('', Validators.required),
    estadoCivil : new FormControl ('', Validators.required)
  });

  formComercio = new FormGroup({
    razonSocial : new FormControl('', Validators.required),
    nombreRepresentante : new FormControl ('', Validators.required),
    apellidoRepresentante : new FormControl('', Validators.required),
    comision : new FormControl('', [Validators.required, Validators.pattern(/^[0-9]*\.?[0-9]*$/)])
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

  constructor(private s_signup : SignupService, private datePipe: DatePipe, private router : Router) { }

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
    this.contrasena = this.formUsuario.get('contra').value;

    this.s_signup.registrarPersona(
        this.formUsuario.get('usuario').value,
        this.formPersona.get('nombre').value,
        this.formPersona.get('apellido').value,
        this.contrasena,
        this.formUsuario.get('correo').value,
        this.formUsuario.get('telefono').value,
        this.formUsuario.get('direccion').value,
        parseInt(this.formUsuario.get('numeroId').value,10),
        this.idTipoUsuario,
        parseInt(this.formUsuario.get('tipoId').value,10),
        parseInt(this.formPersona.get('estadoCivil').value,10),
        parseInt(this.datePipe.transform(this.formPersona.get('fechaNac').value,'yyyy'), 10),
        parseInt(this.datePipe.transform(this.formPersona.get('fechaNac').value,'MM'), 10),
        parseInt(this.datePipe.transform(this.formPersona.get('fechaNac').value,'dd'), 10), 
        "",
        parseInt(this.datePipe.transform(Date.now(),'yyyy'),10),
        parseInt(this.datePipe.transform(Date.now(),'MM'),10),
        parseInt(this.datePipe.transform(Date.now(),'dd'),10))
    .subscribe(
      (res: any)=>{
        alert(res.message);
        this.router.navigate(['/login']);
      },
      (err : HttpErrorResponse) =>{
        if (err.status >= 400){
          alert(err.error.error);
        }
        else {
          alert("Error inesperado. Vuelva a intentar")
        }
      }
    );
  }

  registarComercio(){
    this.contrasena = this.formUsuario.get('contra').value;
    console.log('hola');

    this.s_signup.registrarComercio(
      this.formUsuario.get('usuario').value,
      this.contrasena,
      this.formUsuario.get('correo').value,
      this.formUsuario.get('telefono').value,
      this.formUsuario.get('direccion').value,
      parseInt(this.formUsuario.get('numeroId').value,10),
      parseInt(this.formUsuario.get('tipoId').value,10),
      this.formComercio.get('razonSocial').value,
      this.formPersona.get('apellido').value,
      this.formPersona.get('nombre').value,
      parseFloat(this.formComercio.get('comision').value),
      parseInt(this.datePipe.transform(Date.now(),'yyyy'),10),
      parseInt(this.datePipe.transform(Date.now(),'MM'),10),
      parseInt(this.datePipe.transform(Date.now(),'dd'),10)
      )
  .subscribe(
    (res: any)=>{
      alert(res.message);
      this.router.navigate(['/login']);
    },
    (err : HttpErrorResponse) =>{
      if (err.status >= 400){
        alert(err.error.error);
      }
      else {
        alert("Error inesperado. Vuelva a intentar")
      }
    }
  );
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
