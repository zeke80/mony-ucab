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
    
    let body ={
      "usuario" : usuario,
      "contrasena" : contra,
      "razonSocial" : email,
      "nombre" : telefono,
      "apellido" : direccion,
      "comision" : numIdentificacion,
      "password" : idTipoId,

    }

    return this.http.post(url, body);
  }


  registrarPersona(
    usuario : string,
    nombre : string,
    apellido : string,
    contra : string,
    email : string,
    telefono : string,
    direccion : string,
    nroIdentificacion : number,
    idTipoUsuario : number,
    idTipoIdentificacion : number,
    idEstadoCivil : number,
    anoNacimiento : number,
    mesNacimiento : number,
    diaNacimiento : number,
    razonSocial : string,
    anoRegistro : number,
    mesRegistro : number,
    diaRegistro : number

  ){

    let url = "http://monyucab.somee.com/api/authentication/register";

    let body2 = {
      "usuario": usuario,
      "email": email,
      "password": contra,
      "idTipoUsuario": idTipoUsuario,
      "idTipoIdentificacion": idTipoIdentificacion,
      "idEstadoCivil": idEstadoCivil,
      "anoRegistro":anoRegistro,
      "mesRegistro":mesRegistro,
      "diaRegistro":diaRegistro,
      "nroIdentificacion": nroIdentificacion,
      "telefono": telefono,
      "direccion": direccion,
      "estatus": 1,
      "comercio": false,
      "nombre": nombre,
      "apellido": apellido,
      "anoNacimiento": anoNacimiento,
      "mesNacimiento": mesNacimiento,
      "diaNacimiento":diaNacimiento,
      "razonSocial": razonSocial
  };
    return this.http.post(url, body2);
  }

}
