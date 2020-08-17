import { Component, OnInit } from '@angular/core';
import { AddFamiliarService } from './services/add-familiar.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { SignupService } from 'src/app/home/signup-form/services/signup.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-familiar',
  templateUrl: './add-familiar.component.html',
  styleUrls: ['./add-familiar.component.css']
})
export class AddFamiliarComponent implements OnInit {

  idTipoUsuario = 1;  
  contrasena = '';

  esPersona = true;

  formPersona = new FormGroup({
    nombre : new FormControl ('', Validators.required),
    apellido : new FormControl ('', Validators.required),
    fechaNac : new FormControl ('', Validators.required),
    estadoCivil : new FormControl ('', Validators.required)
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

  constructor(
    public s_add_familiar : AddFamiliarService,
    private datePipe : DatePipe
    ) { }

  ngOnInit(): void {

  }

  registrarPersona(){
    this.contrasena = this.formUsuario.get('contra').value;

    this.s_add_familiar.registrarPersona(
        this.formUsuario.get('usuario').value,
        this.formPersona.get('nombre').value,
        this.formPersona.get('apellido').value,
        this.contrasena,
        this.formUsuario.get('correo').value,
        this.formUsuario.get('telefono').value,
        this.formUsuario.get('direccion').value,
        parseInt(this.formUsuario.get('numeroId').value,10),
        parseInt(localStorage.getItem('userIntID')),
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
        this.s_add_familiar.show = false; 
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
    this.registrarPersona();
  }

}
