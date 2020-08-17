import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResetPasswordService } from './services/reset-password.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  userID: string;
  resetPasswordToken: string;

  contrasenaNueva = new FormGroup({
    contra1 : new FormControl('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required]),
    contra2 : new FormControl('', [Validators.pattern(/(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}/),
    Validators.required])
  });

  constructor(
    private s_reset_password : ResetPasswordService,
    private activatedRoute: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.userID = params.get('userID');
      this.resetPasswordToken = params.get('resetPasswordToken');
    })
  }

  compararContrasenas(){
    if (this.contrasenaNueva.get('contra1').value != this.contrasenaNueva.get('contra2').value){
      alert("Contraseñas no coinciden")
    } else {
      this.restablecerPassword();
    }
  }

  restablecerPassword() {
    var body = {
      idUsuario: this.userID,
      resetPasswordToken: this.resetPasswordToken,
      newPassword: this.contrasenaNueva.get('contra1').value
    };

    this.s_reset_password.resetPassword(body).subscribe(
      (res : any) => {
        console.log(res);

        if (res.key == "ResetPasswordSuccess") {
          alert('Ingrese al portal con su contraseña nueva');
        }
        
        this.router.navigateByUrl('/login');
      },
      err => {
        console.log(err);
        this.contrasenaNueva.reset();
      }
    );
  }

}
