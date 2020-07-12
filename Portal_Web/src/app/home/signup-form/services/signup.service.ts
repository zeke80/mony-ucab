import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private http : HttpClient) { }

  registrarComercio(
    usuario : string,
    contra : string,
    email : string,
    telefono : string,
    direccion : string,
    numIdentificacion : number,
    idTipoId : number,
    razonSocial : string,
    nombre : string,
    apellido: string
  ){
    let url = "http://monyucab.somee.com/api/Usuario/registrarComercio";

    usuario = usuario.toLocaleUpperCase();
    
    let body ={
      "usuario" : usuario,
      "contrasena" : contra,
      "email" : email,
      "telefono" : telefono,
      "direccion" : direccion,
      "nro_identificacion" : numIdentificacion,
      "idtipoidentificacion" : idTipoId,
      "descripciontipoidentificacion" : "RIF",
      "razon_social" : razonSocial,
      "nombre_representante" : nombre,
      "apellido_representante" : apellido

    }

    return this.http.post(url, body);
  }


  registrarPersona(
    usuario : string,
    nombre : string,
    apellido : string,
    contra : string,
    fechaNacimiento : string,
    email : string,
    telefono : string,
    direccion : string,
    nroIdentificacion : number,
    descripcionTipoUsuario : string,
    idTipoUsuario : number,
    idTipoIdentificacion : number,
    descripcionTipoIdentificacion : string,
    idEstadoCivil : number
  ){

    let url = "http://monyucab.somee.com/api/Usuario/registrarUsuario";


    usuario = usuario.toLocaleUpperCase();
    nombre = nombre.toLocaleUpperCase();
    apellido = apellido.toLocaleUpperCase();
    email =  email.toLocaleUpperCase();
    direccion = direccion.toLocaleUpperCase();
    descripcionTipoIdentificacion = descripcionTipoIdentificacion.toLocaleUpperCase();

    let body2 = {
      "usuario" : usuario,
      "nombre" : nombre,
      "apellido" : apellido,
      "contrasena" : contra,
      "fecha_nacimiento": fechaNacimiento,
      "email" : email,
      "telefono" : telefono,
      "direccion" : direccion,
      "nro_identificacion" : nroIdentificacion,
      "idtipoidentificacion" : idTipoIdentificacion,
      "descripciontipoidentificacion" :  descripcionTipoIdentificacion,
      "idestadocivil" : idEstadoCivil
     };
    

    return this.http.post(url, body2);

  }

}
