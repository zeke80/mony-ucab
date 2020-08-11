
import { Component, OnInit } from '@angular/core';

import { Usuario } from './../../models/usuario.model';
import { Persona } from './../../models/persona.model';
import { Comercio } from './../../models/comercio.model';

import { PerfilService } from './services/perfil.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  infoPersona : Persona ={
    estadoCivil : 0,
    nombre : '',
    apellido : '',
    fechaNacimiento : ''
  };

  infoComercio : Comercio ={
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
  idEstadoCivil = 0;

  estados;

  isDisabled : boolean = true;

  constructor(public s_perfil : PerfilService) { }

  ngOnInit(): void {
    this.consutarInfo();
  }

  fechaNacimientoString(fechaNacimiento : any){    
    return fechaNacimiento.year.toString() + '-' + fechaNacimiento.month.toString() + '-' + fechaNacimiento.day.toString();
    ;
  }

  mostrarPersona(data : any){
    if ( data.estadoCivil.codigo == 'C'){
      this.estadoCivil = "Casado"
    }
    else{
      this.estadoCivil = "Soltero"
    }
    this.idEstadoCivil == data.estadoCivil.idEstadoCivil;
    this.infoPersona.nombre = data.persona.nombre;
    this.infoPersona.apellido = data.persona.apellido;
    this.infoPersona.fechaNacimiento = this.fechaNacimientoString(data.persona.fechaNacimiento);
    this.infoUsuario.email = data.result.email;
    this.infoUsuario.telefono = data.result.telefono;
    this.infoUsuario.direccion = data.result.direccion;
    this.infoUsuario.nroIdentificacion = data.result.nroIdentificacion;
    this.tipoIdentificacion = data.tipoIdentificacion.codigo;

  }

  mostrarComercio(data : any){
    console.log('mostrar comercio')
    this.infoPersona.nombre = data.persona.nombre;
    this.infoPersona.apellido = data.persona.apellido;
    this.infoUsuario.email = data.result.email;
    this.infoUsuario.telefono = data.result.telefono;
    this.infoUsuario.direccion = data.result.direccion;
    this.infoUsuario.nroIdentificacion = data.result.nroIdentificacion;
    this.infoComercio.nombreRepresentante = data.comercio.nombreRepresentante;
    this.infoComercio.apellidoRepresentante = data.comercio.apellidoRepresentante;

  }
  consutarInfo(){
    this.s_perfil.consultar().subscribe(
      (data : any) => {
        localStorage.setItem('id', data.result.idUsuario);  
        if (data.comercio.razonSocial == ""){
          this.mostrarPersona(data);
          this.infoComercio = null;
        }
        else{
          this.infoPersona = null;
          this.mostrarComercio(data);
        }
      }
    );

      
    this.infoComercio = null;
  }

  editar(){
    this.isDisabled = false;

    this.s_perfil.consultarEstadosCiviles().subscribe(
      (data : any) => {
        if (data.codigo == 'C'){
          this.estados = "Casado"
        }
        else{
          this.estados = "Soltero"
        }
      }
    );

  }

  cancelar(){
    this.isDisabled = true;
  }

  modificar(){

    if (this.infoPersona == null){
      this.s_perfil.modificar(
        this.infoComercio.nombreRepresentante,
        this.infoComercio.apellidoRepresentante,
        this.infoUsuario.telefono,
        this.infoUsuario.direccion,
        this.infoComercio.razonSocial,
        1
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
       this.s_perfil.modificar(
         this.infoPersona.nombre,
         this.infoPersona.apellido,
         this.infoUsuario.telefono,
         this.infoUsuario.direccion,
         "",
         2
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

    this.s_perfil.refreshInfo
    .subscribe(() =>{
      this.consutarInfo();
    });
      this.cancelar();
  }

}
