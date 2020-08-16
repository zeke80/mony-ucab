import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResetPasswordService } from './services/reset-password.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  contrasenaNueva = new FormGroup({
    contra1 : new FormControl('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required]),
    contra2 : new FormControl('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required])
  });

  constructor(private s_reset_password : ResetPasswordService) { }

  ngOnInit(): void {

  }

  compararContrasenas(){
    if (this.contrasenaNueva.get('contra1').value != this.contrasenaNueva.get('contra2').value){
      alert("Contraseñas no coinciden")
    } else {
      this.restablecerPassword();
    }
  }

  restablecerPassword() {
    
  }

}
