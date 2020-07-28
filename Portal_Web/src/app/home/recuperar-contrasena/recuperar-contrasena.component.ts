
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

  contrasenaNueva = new FormGroup({
    contra1 : new FormControl('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required]),
    contra2 : new FormControl('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required])
  })

  constructor(private s_contrasena : RecuperarContrasenaService) { }

  ngOnInit(): void {
  }

  recuperarContrasena(email : string){
    this.s_contrasena.recuperContrasena(email.toLocaleUpperCase())
    .subscribe((data: any) =>{
      alert('Correo enviado');
    } );
  }

  compararContrasenas(){
    if (this.contrasenaNueva.get('contra1').value != this.contrasenaNueva.get('contra2').value){
      alert("Contraseñas no coinciden")
    }
  }

}

