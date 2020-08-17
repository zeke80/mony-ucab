
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
    correo : new FormControl('', [Validators.email, Validators.required])
  })
  email = '';

  constructor(private s_contrasena : RecuperarContrasenaService) { }

  ngOnInit(): void {
  }

  recuperarContrasena(){
    this.s_contrasena.recuperContrasena(this.recuperarContrasenaFormulario.get('correo').value)
    .subscribe((data: any) =>{
      alert('Correo enviado');
    } );
  }

}

