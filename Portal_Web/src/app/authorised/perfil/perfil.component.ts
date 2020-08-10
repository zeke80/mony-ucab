
import { Component, OnInit } from '@angular/core';

import { Usuario } from './../../models/usuario.model';
import { Persona } from './../../models/persona.model';
import { Comercio } from './../../models/comercio.model';

import { PerfilService } from './services/perfil.service';
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
    this.consutarPersona();
  }

  fechaNacimientoString(fechaNacimiento : any){    
    return fechaNacimiento.year.toString() + '-' + fechaNacimiento.month.toString() + '-' + fechaNacimiento.day.toString();
    ;
  }

  consutarPersona(){
    this.s_perfil.consultar().subscribe(
      (data : any) => {
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
    );/*this.s_perfil.consultarPersona().subscribe((data : any) => {
      if (data.idestadocivil == 1){
        this.estadoCivil = "SOLTERO"
      }
      else {
        this.estadoCivil = "CASADO"
      }
      this.infoPersona.nombre = data.nombre;
      this.infoPersona.apellido = data.apellido;
      this.infoPersona.fechaNacimiento = data.fecha_nacimiento;
    }
    ); */
    
    this.infoComercio = null;
  }

  editar(){
    this.isDisabled = false;

    this.s_perfil.consultarEstadosCiviles().subscribe(
      (data : any) => {
        console.log(data);
        if (data.codigo == 'C'){
          this.estados = "Casado"
          console.log("gola")
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

  guardarCambios(){

    


   /* this.s_perfil.ajustarUsuario(
      this.infoUsuario.email, this.infoUsuario.telefono, this.infoUsuario.direccion, this.infoUsuario.nroIdentificacion)
      .subscribe((data : any) =>{
    });


    if(this.infoUsuario.idTipoUsuario == 1){      
      this.s_perfil.ajustarPersona(this.infoPersona.nombre, this.infoPersona.apellido).subscribe((data:any) => 
      {
        if (data ==true)
        alert('Cambios guardados');
      })
    }
    else if (this.infoUsuario.idTipoUsuario == 2) {
      this.s_perfil.ajustarComercio(this.infoComercio.razonSocial, this.infoComercio.nombreRepresentante, this.infoComercio.apellidoRepresentante)
      .subscribe((data : any) =>{
          if (data ==true)
          alert('Cambios guardados');
          
      });}
       */
      this.cancelar();
  }

}
