import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/models/usuario.model';
import { Comercio } from 'src/app/models/comercio.model';
import { Persona } from 'src/app/models/persona.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { EditUserService } from './services/edit-user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  user : any;

  formComercio = new FormGroup({
    razonSocial : new FormControl({value: '', disabled: true}, Validators.required)
  });

  formUsuario = new FormGroup({
    nombre : new FormControl( {value: '', disabled: true} , Validators.required),
    apellido : new FormControl ({value: '', disabled: true}, Validators.required),
    telefono : new FormControl ({value: '', disabled: true}, [Validators.pattern(/^[0-9]*$/), Validators.required]),
    direccion : new FormControl ({value: '', disabled: true}, Validators.required)
  }); 

  infoPersona : Persona = {
    estadoCivil : 0,
    nombre : '',
    apellido : '',
    fechaNacimiento : ''
  };

  infoComercio : Comercio = {
    razonSocial : '',
    nombreRepresentante : '',
    apellidoRepresentante : ''
  };

  infoUsuario : Usuario = {
    idUsuario : 0,
    idTipoUsuario : 0,
    idTipoIdentificacion : 0,
    usuario : '',
    fechaRegistro : '',
    nroIdentificacion : 0,
    email : '',
    telefono : '',
    direccion : '',
    estatus : 0
  };

  estadoCivil = '';
  tipoIdentificacion = '';
  idEstadoCivil;

  isDisabled : boolean = true;

  constructor(public s_edit_user : EditUserService) { }

  ngOnInit(): void {
    
    this.s_edit_user.refreshNeeded$.subscribe(() => {
      this.consutarInfo();
      }
    );
    
    this.consutarInfo();
  }

  fechaNacimientoString(fechaNacimiento : any){    
    return fechaNacimiento.year.toString() + '-' + fechaNacimiento.month.toString() + '-' + fechaNacimiento.day.toString();
    ;
  }

  codigosAStringEstados(data : any){
    if (data.codigo == 'C'){
      return "Casado";
    }
    else{
      return "Soltero";
    }
  }
  
  mostrarPersona(data : any){
    this.estadoCivil = this.codigosAStringEstados(data.estadoCivil);
    this.idEstadoCivil = data.estadoCivil.idEstadoCivil;
    this.infoPersona.fechaNacimiento = this.fechaNacimientoString(data.persona.fechaNacimiento);
    this.infoUsuario.email = data.result.email;
    this.infoUsuario.nroIdentificacion = data.result.nroIdentificacion;
    this.tipoIdentificacion = data.tipoIdentificacion.codigo;
    this.formUsuario.get('nombre').patchValue(data.persona.nombre);
    this.formUsuario.get('apellido').patchValue(data.persona.apellido);
    this.formUsuario.get('telefono').patchValue(data.result.telefono);
    this.formUsuario.get('direccion').patchValue(data.result.direccion);
  }

  mostrarComercio(data : any){
    this.infoUsuario.email = data.result.email;
    this.infoUsuario.nroIdentificacion = data.result.nroIdentificacion;
    this.tipoIdentificacion = data.tipoIdentificacion.codigo;
    this.formUsuario.get('nombre').patchValue(data.comercio.nombreRepresentante);
    this.formUsuario.get('apellido').patchValue(data.comercio.apellidoRepresentante);
    this.formUsuario.get('telefono').patchValue(data.result.telefono);
    this.formUsuario.get('direccion').patchValue(data.result.direccion);
    this.formComercio.get('razonSocial').patchValue(data.comercio.razonSocial);
  }

  consutarInfo() {
    //this.formUsuario.disable();
    this.s_edit_user.editUsuario(this.s_edit_user.userEmail).subscribe(
      (data : any) => {
        this.user = data;
        if (this.user.comercio.razonSocial == ""){
          this.infoComercio = null;
          this.mostrarPersona(this.user);
        }
        else{
          this.infoPersona = null;
          this.mostrarComercio(this.user);
        }
      }
    );
  }

  editar(){
    this.isDisabled = false;
    this.formUsuario.enable();
    this.formComercio.enable();
  }

  cancelar(){
    this.isDisabled = true;
    this.formUsuario.disable();
    this.formComercio.disable();
  }

  modificar(){
    if (this.infoComercio == null){
      this.s_edit_user.modificar(
        this.formUsuario.get('nombre').value,
        this.formUsuario.get('apellido').value,
        this.formUsuario.get('telefono').value,
        this.formUsuario.get('direccion').value,
        "",
        parseInt(this.idEstadoCivil, 10)
      ).subscribe(  
        (data : any) => {
          alert(data.message);
        },
        (err : HttpErrorResponse) =>{
          alert(err.error);
        }
        );  
    }
     else {
       this.s_edit_user.modificar(
        this.formUsuario.get('nombre').value,
        this.formUsuario.get('apellido').value,
        this.formUsuario.get('telefono').value,
        this.formUsuario.get('direccion').value,
        this.formComercio.get('razonSocial').value,
        0
       ).subscribe(  
        (data : any) => {
          alert(data.message);
        },
        (err : HttpErrorResponse) =>{
          alert(err.error);
        }
        );  
     } 
  }

  guardarCambios(){
    this.modificar();

    this.s_edit_user.refreshNeeded$
    .subscribe(() =>{
      this.consutarInfo();
    });

    this.consutarInfo();
    this.cancelar();
  }

}
