import { AdminUsuariosService } from './../admin-usuarios/services/admin-usuarios.service';
import { Parametro } from './../../models/parametro.model';
import { FormBuilder, Validators } from '@angular/forms';
import { EstablecerLimiteService } from './services/establecer-limite.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-establecer-limite',
  templateUrl: './establecer-limite.component.html',
  styleUrls: ['./establecer-limite.component.css']
})
export class EstablecerLimiteComponent implements OnInit {

  parametros : any;
  idParametro = 0;
  limite = 0;

  parametroFormModel = this.formBuilder.group({
    ParametroID: ['', Validators.required],
    Validacion: ['', Validators.required]
  });

  constructor(public s_limite : EstablecerLimiteService,
              private formBuilder: FormBuilder, 
              private s_admin : AdminUsuariosService) { }

  ngOnInit(): void {
    this.consultarParametros();
  }

  consultarParametros(){
    this.s_limite.getParametro().subscribe(
      (data : any) => {
        this.parametros = data;

      },
      (err : any) =>{
        console.log(err);
      }
    );
  }

    establecerLimite(){
    this.s_limite.setLimite(this.limite.toString(), this.idParametro).subscribe(
      (data : any) => {
        alert(data.message);
      },
      (err : any) =>{
        console.log(err)
      }
    );
  }

  onClickEstablecerLimite(){
      this.establecerLimite();
      this.s_limite.refreshInfo
    .subscribe(() =>{
      this.consultarParametros();
    });
  }

}
