
import { Component, OnInit } from '@angular/core';

import { RecuperarContrasenaService } from './services/recuperar-contrasena.service';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-recuperar-contrasena',
  templateUrl: './recuperar-contrasena.component.html',
  styleUrls: ['./recuperar-contrasena.component.css']
})
export class RecuperarContrasenaComponent implements OnInit {

  recuperarContrasenaFormulario = new FormGroup({
    correo : new FormControl('', Validators.email)
  })
  email = '';

  constructor(private s_contrasena : RecuperarContrasenaService) { }

  ngOnInit(): void {
  }

  recuperarContrasena(email : string){
    this.s_contrasena.recuperContrasena(email.toLocaleUpperCase())
    .subscribe((data: any) =>{
      alert('Correo enviado');
    } );
  }

  get correo (): AbstractControl{
    return this.recuperarContrasenaFormulario.get('correo'); 
  }
}

